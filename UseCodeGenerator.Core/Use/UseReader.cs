﻿using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using UseCodeGenerator.Core.Use.SyntaxAnalizer;
using UseCodeGenerator.Core.Use.Entities;

namespace UseCodeGenerator.Core.Use;

internal class UseReader
{
    public UModel Read(string text)
    {
        AntlrInputStream inputStream = new AntlrInputStream(text);
        Lexer lexer = new UseLexer(inputStream);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        UseParser parser = new UseParser(tokens);
        UseVisitor visitor = new UseVisitor();

        return visitor.VisitStartRule(parser.startRule());
    }

    class UseVisitor : UseBaseVisitor<object>
    {
        private UModel Model { get; set; }
        private List<ClassToken> ClassTokens { get; set; }

        public override UModel VisitStartRule([NotNull] UseParser.StartRuleContext context)
        {
            Model = VisitModel(context.model());

            // Primero visitamos los tipos en anchura
            ClassTokens = new List<ClassToken>();
            VisitAllTypesInBreadth(context);

            // Una vez obtenido todos los tipos, los visitamos en profundidad
            VisitAllTypesInDepth();

            // Visitamos todas las asociaciones
            VisitAllAssociations(context);

            return Model;
        }

        public override UModel VisitModel([NotNull] UseParser.ModelContext context)
        {
            string name = context.modelName().GetText();

            return new UModel(name);
        }

        private void VisitAllTypesInBreadth([NotNull] UseParser.StartRuleContext context)
        {
            foreach (var enumContext in context.enumeration())
            {
                UEnumeration @enum = VisitEnumeration(enumContext);
                Model.AddEnumeration(@enum);
            }

            foreach (var classContext in context.@class())
            {
                UClass @class = VisitClass(classContext);
                ClassTokens.Add(new ClassToken(@class, classContext));
                Model.AddClass(@class);
            }
        }

        private void VisitAllTypesInDepth()
        {
            foreach (ClassToken classToken in ClassTokens)
            {
                VisitClass(classToken.Class, classToken.Context);
            }
        }

        private void VisitAllAssociations([NotNull] UseParser.StartRuleContext context)
        {
            foreach (var associationContext in context.association())
            {
                UAssociation association = VisitAssociation(associationContext);
                Model.AddAssociation(association);
            }
        }

        #region Class

        public override UClass VisitClass([NotNull] UseParser.ClassContext context)
        {
            string name = context.className().GetText();
            bool isAbstract = context.ABSTRACT() != null;

            return new UClass(name, isAbstract);
        }

        private void VisitClass(UClass @class, [NotNull] UseParser.ClassContext context)
        {
            var inheritanceContext = context.inheritance();

            if (inheritanceContext != null)
            {
                foreach (var parentContext in inheritanceContext.className())
                {
                    string className = parentContext.GetText();
                    UClass parent = Model.Classes[className];

                    @class.AddParent(parent);
                }
            }

            foreach (var attributeContext in context.attribute())
            {
                UAttribute attribute = VisitAttribute(attributeContext);

                @class.AddAttribute(attribute);
            }

            foreach (var operationContext in context.operation())
            {
                UOperation operation = VisitOperation(operationContext);

                @class.AddOperation(operation);
            }
        }

        public override UAttribute VisitAttribute([NotNull] UseParser.AttributeContext context)
        {
            string name = context.ID().GetText();
            UType type = GetType(context.type().GetText());
            string initValue = GetInitValue(context.typeLiteral());

            return new UAttribute(name, type, initValue);
        }

        private string GetInitValue(UseParser.TypeLiteralContext context)
        {
            bool isString = context?.simpleTypeLiteral()?.stringLiteral() != null;

            return isString 
                ? context.GetText().Replace("'", "")
                : context?.GetText();
        }

        public override UOperation VisitOperation([NotNull] UseParser.OperationContext context)
        {
            UOperation operation;
            string name = context.ID().GetText();
            string returnTypeName = context.type()?.GetText();
            UType returnType = null;

            if (!string.IsNullOrEmpty(returnTypeName))
            {
                returnType = GetType(returnTypeName);
            }

            operation = new UOperation(name, returnType);

            foreach (var parameterContext in context.parameter())
            {
                UParameter parameter = VisitParameter(parameterContext);
                operation.Parameters.Add(parameter);
            }

            return operation;
        }

        public override UParameter VisitParameter([NotNull] UseParser.ParameterContext context)
        {
            string name = context.ID().GetText();
            UType type = GetType(context.type().GetText());

            return new UParameter()
            {
                Name = name,
                Type = type,
            };
        }

        private UType GetType(string name)
        {
            UType type;

            if (Enum.TryParse(name, true, out UPrimitiveType.Kind kind))
            {
                type = new UPrimitiveType(kind);
            }
            else
            {
                type = Model.FindType(name);
            }

            return type;
        }

        class ClassToken
        {
            public UClass Class { get; }
            public UseParser.ClassContext Context { get; }

            public ClassToken(UClass @class, UseParser.ClassContext context)
            {
                Class = @class;
                Context = context;
            }
        }

        #endregion

        #region Enumeration

        public override UEnumeration VisitEnumeration([NotNull] UseParser.EnumerationContext context)
        {
            string name = context.enumerationName().GetText();
            IEnumerable<string> values = context.enumerationLiteral()
                .Select(node => node.GetText());

            return new UEnumeration(name, values);
        }

        #endregion

        #region Association

        public override UAssociation VisitAssociation([NotNull] UseParser.AssociationContext context)
        {
            string name = context.associationName().GetText();
            UAssociation association = new UAssociation(name);

            foreach (var itemContext in context.associationItem())
            {
                UAssociation.Item item = new UAssociation.Item()
                {
                    ClassName = itemContext.className().GetText(),
                    Multiplicity = VisitMultiplicity(itemContext.multiplicity()),
                    Role = itemContext.roleName().GetText(),
                };

                association.Items.Add(item);
            }

            return association;
        }

        public override UAssociation.Multiplicity VisitMultiplicity([NotNull] UseParser.MultiplicityContext context)
        {
            UAssociation.Multiplicity multiplicity;
            var multiplicityContexts = context.multiplicityValue();

            int MultiplicityToInt(UseParser.MultiplicityValueContext mult)
            {
                string multText = mult.GetText();

                return multText == "*" ? UAssociation.Multiplicity.Infinity : int.Parse(multText);
            }

            if (multiplicityContexts.Length == 1)
            {
                int multiplicityInt = MultiplicityToInt(multiplicityContexts[0]);
                multiplicity = new UAssociation.Multiplicity(multiplicityInt);
            }
            else
            {
                int min = MultiplicityToInt(multiplicityContexts[0]);
                int max = MultiplicityToInt(multiplicityContexts[1]);
                multiplicity = new UAssociation.Multiplicity(min, max);
            }

            return multiplicity;
        }

        #endregion
    }
}

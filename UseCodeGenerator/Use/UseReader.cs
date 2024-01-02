using System.Reflection;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using UseCodeGenerator.Use.Entities;
using UseCodeGenerator.Use.SyntaxAnalizer;
using UAttribute = UseCodeGenerator.Use.Entities.UAttribute;

namespace UseCodeGenerator.Use;

public class UseReader
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

    class UseVisitor : UseBaseVisitor<object?>
    {
        private UModel Model { get; set; }
        private List<ClassToken> ClassTokens { get; set; }

        public override UModel VisitStartRule([NotNull] UseParser.StartRuleContext context)
        {
            Model = VisitModel(context.model());

            // Primero visitamos los tipos en anchura
            ClassTokens = new List<ClassToken>();
            VisitAllTypesInBreadth(context);

            // Una vez obtenido todos los tipos, visitamos en profundidad
            VisitAllTypesInDeth();

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

        private void VisitAllTypesInDeth()
        {
            foreach (var classToken in ClassTokens)
            {
                VisitClass(classToken.Class, classToken.Context);
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
            UType type = Model.FindType(context.type().GetText());
            string initValue = context.typeLiteral()?.GetText();

            return new UAttribute(name, type, initValue);
        }

        public override UOperation VisitOperation([NotNull] UseParser.OperationContext context)
        {
            string name = context.ID().GetText();
            string returnTypeName = context.type()?.GetText();
            UType returnType = null;

            if (!string.IsNullOrEmpty(returnTypeName))
            {
                returnType = Model.FindType(returnTypeName);
            }

            return new UOperation(name, returnType);
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
    }
}

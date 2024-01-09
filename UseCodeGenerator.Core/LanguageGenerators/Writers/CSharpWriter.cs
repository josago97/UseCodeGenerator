using System;
using UseCodeGenerator.Core.LanguageGenerators.Entities;
using UseCodeGenerator.Utilities;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal class CSharpWriter : LanguageWriter
{
    private const string FILE_EXTENSION = "cs";

    protected override string FileExtension => FILE_EXTENSION;

    protected override void MakeClass(LClass @class, CodeBuilder builder)
    {
        WriteNamespace(builder);
        builder.WriteLine();
        WriteClassHeader(@class, builder);
        builder.WriteLine("{");
        builder.AddTab();
        WriteProperties(@class.Attributes, builder);
        builder.WriteLine();
        WriteMethods(@class.Methods, builder);
        builder.RemoveTab();
        builder.WriteLine("}");
        builder.WriteLine();
    }

    private void WriteClassHeader(LClass @class, CodeBuilder builder)
    {
        builder.Write("public ");

        if (@class.IsAbstract)
        {
            builder.Write("abstract ");
        }

        builder.Write($"class {@class.Name.ToPascalCase()}");

        if (@class.Parents.Length > 0)
        {
            builder.Write(" " + string.Join(", ", @class.Parents));
        }

        builder.WriteLine();
    }

    private void WriteProperties(IEnumerable<LAttribute> attributes, CodeBuilder builder)
    {
        foreach (LAttribute attribute in attributes)
        {
            string name = attribute.Name.ToPascalCase();
            string type = GetTypeName(attribute.Type);

            builder.Write($"public {type} {name} {{ get; set; }}");

            if (attribute.InitValue != null)
            {
                builder.Write($" = {attribute.InitValue}");
            }

            builder.WriteLine();
        }
    }

    private void WriteMethods(IEnumerable<LMethod> methods, CodeBuilder builder)
    {
        foreach (LMethod method in methods)
        {
            string name = method.Name.ToPascalCase();
            string returnType = GetReturnType(method.ReturnType);

            builder.WriteLine($"public {returnType} {name}()");
            builder.WriteLine("{ }");
        }
    }

    private string GetReturnType(LType type)
    {
        return type switch
        {
            null => "void",
            _ => GetTypeName(type)
        };
    }

    protected override void MakeEnumeration(LEnumeration enumeration, CodeBuilder builder)
    {
        WriteNamespace(builder);
        builder.WriteLine();
        builder.WriteLine($"public enum {enumeration.Name}");
        builder.WriteLine("{");
        builder.AddTab();
        builder.WriteLine(string.Join(",\n", enumeration.Values));
        builder.RemoveTab();
        builder.WriteLine("}");
    }

    private void WriteNamespace(CodeBuilder builder)
    {
        builder.WriteLine($"namespace {Project.Name.ToPascalCase()};");
    }

    private string GetTypeName(LType type)
    {
        return type switch
        {
            LPrimitiveType primitive => primitive.Type switch
            {
                LPrimitiveType.Kind.Boolean => "bool",
                LPrimitiveType.Kind.Integer => "int",
                LPrimitiveType.Kind.Real => "double",
                LPrimitiveType.Kind.String => "string",
                _ => throw new Exception($"Unknown type {type}")
            },
            LCustomType custom => custom.Name,
            LCollectionType collection => $"IList<{GetTypeName(collection.Type)}>",
            _ => "object"
        };
    }

    protected override string GetFileName(ILTypeDefinition typeDefinition)
    {
        return typeDefinition.Name.ToPascalCase();
    }

    //private 


    /*
    private const string CLASS = "class";
    private const string ABSTRACT = "abstract";

    public CSharpCodeGenerator(Model model) : base(model)
    {
    }

    public override void Generate(string outputFolder)
    {
        base.Generate(outputFolder);

        string @namespace = Model.Name;

        foreach (Class @class in Model.Classes)
        {
            string outPath = $"{outputFolder}/{@class.Name}.cs";
            File.WriteAllText(outPath, CreateClass(@namespace, @class));
        }
    }

    public string CreateClass(string @namespace, Class @class)
    {
        string classType = "class";

        if (@class.IsAbstract) classType = "abstract" + " " + classType;

        return $$"""
            namespace {{@namespace}};

            public {{classType}} {{@class.Name}} 
            {
            {{CreateAttributes(@class.Attributes)}}

            {{CreateProperties(@class.Attributes)}}
            }
            """;
    }

    public string CreateAttributes(IList<Attribute> attributes)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (Attribute attribute in attributes)
        {
            stringBuilder.Append(TAB);
            stringBuilder.AppendLine($"private {attribute.Type} {attribute.Name};");
        }

        return stringBuilder.ToString();
    }

    public string CreateProperties(IList<Attribute> attributes)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (Attribute attribute in attributes)
        {
            string property = $$"""
                public {{attribute.Type}} {{attribute.Name.ToPascalCase()}}
                {
                {{TAB}}get => {{attribute.Name}};
                {{TAB}}set => {{attribute.Name}} = value;
                }
                """;

            stringBuilder.Append(TAB);
            stringBuilder.AppendLine(property);
        }

        return stringBuilder.ToString();
    }

    protected override string MakeClass(Class @class)
    {
        throw new NotImplementedException();
    }*/

}

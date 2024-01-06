using UseCodeGenerator.Core.LanguageGenerators.Entities;
using UseCodeGenerator.Utilities;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal class JavaWriter : LanguageWriter
{
    private const string FILE_EXTENSION = "java";

    protected override string FileExtension => FILE_EXTENSION;

    protected override void MakeClass(LClass @class, CodeBuilder builder)
    {
        WritePackage(builder);
        builder.WriteLine();
        WriteClassHeader(@class, builder);
        builder.WriteLine(" {");
        builder.WriteLine();
        builder.AddTab();
        WriteProperties(@class.Attributes, builder);
        builder.WriteLine();
        WriteMethods(@class.Methods, builder);
        builder.RemoveTab();
        builder.WriteLine();
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
            builder.Write($" extends {string.Join(", ", @class.Parents)}");
        }
    }

    private void WriteProperties(IEnumerable<LAttribute> attributtes, CodeBuilder builder)
    {
        var attributesInfo = attributtes.Select(a => new
        {
            a.Type,
            Name = a.Name.ToCamelCase(),
        });

        foreach (var attribute in attributesInfo)
        {
            builder.WriteLine($"private {attribute.Type} {attribute.Name};");
        }

        foreach (LAttribute attribute in attributtes)
        {
            builder.WriteLine($"public {attribute.Type} {attribute.Name} {{ get; set; }}");
        }
    }

    private void WriteMethods(IEnumerable<LMethod> methods, CodeBuilder builder)
    {
        foreach (LMethod method in methods)
        {
            string name = method.Name.ToCamelCase();
            string returnType = GetReturnTypeName(method.ReturnType);

            builder.WriteLine($"public {returnType} {name}() {{");
            builder.WriteLine("}");
        }
    }

    private string GetReturnTypeName(LType type)
    {
        return type switch
        {
            _ => "void"
        };
    }

    protected override void MakeEnumeration(LEnumeration enumeration, CodeBuilder builder)
    {
        WritePackage(builder);
        builder.WriteLine();
        builder.WriteLine();
        builder.WriteLine($"public enum {enumeration.Name.ToPascalCase()} {{");
        builder.AddTab();
        builder.WriteLine(string.Join(",\n", enumeration.Values));
        builder.RemoveTab();
        builder.WriteLine("}");
    }

    private void WritePackage(CodeBuilder builder)
    {
        builder.WriteLine($"package {Project.Name.ToLower()};");
    }

    private string GetTypeName(LType type)
    {
        return type switch
        {
            LPrimitiveType primitive => primitive.Type switch 
            { 
                LPrimitiveType.Kind.Boolean => "boolean",
                LPrimitiveType.Kind.Integer => "int",
                LPrimitiveType.Kind.Real => "double",
                LPrimitiveType.Kind.String => "string",
                _ => throw new Exception($"Unknown type {type}")
            },
            _ => throw new Exception($"Unknown type {type}")
        };
    }

    /*
    public string CreateClass(string @namespace, Class @class)
    {
        string classType = "class";

        if (@class.IsAbstract) classType = "abstract" + " " + classType;

        return $$"""
            package {{@namespace}};

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
            string getter = $$"""
                public {{attribute.Type}} get{{attribute.Name.ToPascalCase()}}() {
                {{TAB}}return {{attribute.Name}};
                }
                """;

            string setter = $$"""
                public {{attribute.Type}} set{{attribute.Name.ToPascalCase()}}({{attribute.Type}} {{attribute.Name}}) {
                {{TAB}}this.{{attribute.Name}} = {{attribute.Name}};
                }
                """;

            stringBuilder.Append(TAB);
            stringBuilder.AppendLine(getter);
            stringBuilder.Append(TAB);
            stringBuilder.AppendLine(setter);
        }

        return stringBuilder.ToString();
    }*/


    protected override string GetFileName(ILTypeDefinition typeDefinition)
    {
        return typeDefinition.Name.ToPascalCase();
    }
}

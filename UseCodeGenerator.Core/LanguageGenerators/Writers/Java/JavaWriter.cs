using System;
using UseCodeGenerator.Core.LanguageGenerators.Entities;
using UseCodeGenerator.Utilities;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers.Java;

internal class JavaWriter : LanguageWriter<JavaOptions>
{
    private const string FILE_EXTENSION = "java";

    private ImportHandler _imports;

    protected override string FileExtension => FILE_EXTENSION;

    #region Class

    protected override void MakeClass(LClass @class, CodeBuilder builder)
    {
        _imports = new ImportHandler();

        CodeBuilder classBuilder = CreateCodeBuilder();
        WriteClass(@class, classBuilder);
        string classText = classBuilder.ToStringWithTrim();

        WritePackage(builder);
        builder.WriteLine();

        if (!_imports.IsEmpty)
        {
            WriteImports(builder);
            builder.WriteLine();
        }

        builder.WriteLine(classText);
    }

    private void WriteClass(LClass @class, CodeBuilder builder)
    {
        WriteClassHeader(@class, builder);

        builder.WriteLine(" {");
        builder.AddTab();

        CodeBuilder bodyBuilder = CreateCodeBuilder();
        WriteClassBody(@class, bodyBuilder);
        string bodyText = bodyBuilder.ToStringWithTrim();
        builder.WriteLine(bodyText);

        builder.RemoveTab();
        builder.WriteLine("}");
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

    private void WriteClassBody(LClass @class, CodeBuilder builder)
    {
        if (@class.Attributes.Length > 0)
        {
            AttributeInfo[] attributesInfo = @class.Attributes.Select(a => new AttributeInfo
            (
                Name: a.Name.ToCamelCase(),
                Type: GetTypeName(a.Type),
                InitValue: GetInitValueText(a)
            ))
            .ToArray();

            WriteAttributes(attributesInfo, builder);
            WriteProperties(attributesInfo, builder);
        }

        if (@class.Methods.Length > 0)
        {
            builder.WriteLine();
            WriteMethods(@class.Methods, builder);
        }
    }

    private void WriteAttributes(AttributeInfo[] attributtes, CodeBuilder builder)
    {
        foreach (AttributeInfo attribute in attributtes)
        {
            string name = attribute.Name;
            string type = attribute.Type;
            string initValue = attribute.InitValue;

            builder.Write($"private {type} {name}");

            if (!string.IsNullOrEmpty(initValue))
            {
                builder.Write($" = {initValue}");
            }

            builder.WriteLine(";");
        }
    }

    private void WriteProperties(AttributeInfo[] attributtes, CodeBuilder builder)
    {
        for (int i = 0; i < attributtes.Length; i++)
        {
            AttributeInfo attribute = attributtes[i];
            string attributeName = attribute.Name;
            string attributeNamePascal = attributeName.ToPascalCase();
            string type = attribute.Type;

            builder.WriteLine();

            // Getter
            builder.WriteLine($"public {type} get{attributeNamePascal}() {{");
            builder.AddTab();
            builder.WriteLine($"return {attributeName};");
            builder.RemoveTab();
            builder.WriteLine("}");

            builder.WriteLine();

            // Setter
            builder.WriteLine($"public void set{attributeNamePascal}({type} {attributeName}) {{");
            builder.AddTab();
            builder.WriteLine($"this.{attributeName} = {attributeName};");
            builder.RemoveTab();
            builder.WriteLine("}");
        }
    }

    private void WriteMethods(IEnumerable<LMethod> methods, CodeBuilder builder)
    {
        foreach (LMethod method in methods)
        {
            string name = method.Name.ToCamelCase();
            string returnType = GetReturnTypeName(method.ReturnType);
            string parameters = string.Join(", ", method.Parameters.Select(GetParameter));

            builder.WriteLine($"public {returnType} {name}({parameters}) {{");
            builder.WriteLine("}");
            builder.WriteLine();
        }
    }

    private string GetParameter(LParameter parameter)
    {
        string name = parameter.Name.ToPascalCase();
        string type = GetTypeName(parameter.Type);

        return $"{type} {name}";
    }

    private string GetReturnTypeName(LType type)
    {
        return type switch
        {
            null => "void",
            _ => GetTypeName(type)
        };
    }

    #endregion

    #region Enumeration

    protected override void MakeEnumeration(LEnumeration enumeration, CodeBuilder builder)
    {
        WritePackage(builder);
        builder.WriteLine();
        builder.WriteLine($"public enum {enumeration.Name.ToPascalCase()} {{");

        if (enumeration.Values.Length > 0)
        {
            builder.AddTab();
            builder.WriteLine(string.Join(",\n", enumeration.Values));
            builder.RemoveTab();
        }

        builder.WriteLine("}");
    }

    #endregion

    #region Common

    protected override string GetFileName(LCustomType customType)
    {
        return customType.Name.ToPascalCase();
    }

    private void WriteImports(CodeBuilder builder)
    {
        foreach (string item in _imports.Items)
        {
            builder.WriteLine($"import {item};");
        }
    }

    private void WritePackage(CodeBuilder builder)
    {
        builder.WriteLine($"package {Project.Name.ToLower()};");
    }

    private string GetTypeName(LType type)
    {
        if (type is LCollectionType)
        {
            _imports.AddImport("java.util.ArrayList");
        }

        return type switch
        {
            LPrimitiveType primitive => primitive.Type switch
            {
                LPrimitiveType.Kind.Boolean => "boolean",
                LPrimitiveType.Kind.Integer => "int",
                LPrimitiveType.Kind.Real => "double",
                LPrimitiveType.Kind.String => "String",
                _ => throw new Exception($"Unknown type {type}")
            },
            LCustomType custom => custom.Name,
            LCollectionType collection => $"ArrayList<{GetTypeName(collection.Type)}>",
            _ => "Object"
        };
    }

    private string GetInitValueText(LAttribute attribute)
    {
        string result = null;
        LType type = attribute.Type;
        object initValue = attribute.InitValue;

        if (type is LCollectionType collectionType)
        {
            result = $"new ArrayList<{GetTypeName(collectionType.Type)}>()";
        }
        else if (initValue != null)
        {
            result = initValue switch
            {
                string => $"\"{initValue}\"",
                _ => initValue.ToString()
            };
        }

        return result;
    }

    #endregion



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

    private record AttributeInfo(string Name, string Type, string InitValue);

    private class ImportHandler : BaseImportHandler
    {
        public HashSet<string> Items { get; }

        public override bool IsEmpty => Items.Count == 0;

        public ImportHandler()
        {
            Items = new HashSet<string>();
        }

        public void AddImport(string item)
        {
            Items.Add(item);
        }
    }
}

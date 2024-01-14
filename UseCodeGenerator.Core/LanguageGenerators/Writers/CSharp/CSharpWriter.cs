using UseCodeGenerator.Core.LanguageGenerators.Entities;
using UseCodeGenerator.Utilities;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers.CSharp;

internal class CSharpWriter : LanguageWriter<CSharpOptions>
{
    private const string FILE_EXTENSION = "cs";

    private ImportHandler _imports;

    protected override string FileExtension => FILE_EXTENSION;

    #region Class

    protected override void MakeClass(LClass @class, CodeBuilder builder)
    {
        _imports = new ImportHandler();

        CodeBuilder classBuilder = CreateCodeBuilder();
        WriteClass(@class, classBuilder);
        string classText = classBuilder.ToStringWithTrim();

        if (!_imports.IsEmpty)
        {
            WriteImports(builder);
            builder.WriteLine();
        }

        WriteNamespace(builder);
        builder.WriteLine();
        builder.WriteLine(classText);
    }

    private void WriteClass(LClass @class, CodeBuilder builder)
    {
        WriteClassHeader(@class, builder);

        builder.WriteLine();
        builder.WriteLine("{");
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
            builder.Write(" : " + string.Join(", ", @class.Parents));
        }
    }

    private void WriteClassBody(LClass @class, CodeBuilder builder)
    {
        if (@class.Attributes.Length > 0)
        {
            WriteProperties(@class.Attributes, builder);
        }

        if (@class.Methods.Length > 0)
        {
            builder.WriteLine();
            WriteMethods(@class.Methods, builder);
        }
    }

    private void WriteProperties(IEnumerable<LAttribute> attributes, CodeBuilder builder)
    {
        foreach (LAttribute attribute in attributes)
        {
            string name = attribute.Name.ToPascalCase();
            string type = GetTypeName(attribute.Type);
            string initValue = GetInitValueText(attribute);

            builder.Write($"public {type} {name} {{ get; set; }}");

            if (!string.IsNullOrEmpty(initValue))
            {
                builder.Write($" = {initValue};");
            }

            builder.WriteLine();
        }
    }

    private void WriteMethods(IEnumerable<LMethod> methods, CodeBuilder builder)
    {
        foreach (LMethod method in methods)
        {
            string name = method.Name.ToCamelCase();
            string returnType = GetReturnTypeName(method.ReturnType);
            string parameters = string.Join(", ", method.Parameters.Select(GetParameter));

            builder.WriteLine($"public {returnType} {name}({parameters})");
            builder.WriteLine("{ }");
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
        WriteNamespace(builder);
        builder.WriteLine();
        builder.WriteLine($"public enum {enumeration.Name.ToPascalCase()}");
        builder.WriteLine("{");

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
        foreach (string @namespace in _imports.Namespaces)
        {
            builder.WriteLine($"using {@namespace};");
        }
    }

    private void WriteNamespace(CodeBuilder builder)
    {
        builder.WriteLine($"namespace {Project.Name.ToPascalCase()};");
    }

    private string GetTypeName(LType type)
    {
        if (type is LCollectionType)
        {
            _imports.AddImport("System.Collections.Generic");
        }

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
            LCustomType custom => custom.Name.ToPascalCase(),
            LCollectionType collection => $"IList<{GetTypeName(collection.Type)}>",
            _ => "object"
        };
    }

    private string GetInitValueText(LAttribute attribute)
    {
        string result = null;
        LType type = attribute.Type;
        object initValue = attribute.InitValue;

        if (type is LCollectionType collectionType)
        {
            result = $"new List<{GetTypeName(collectionType.Type)}>()";
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

    private class ImportHandler : BaseImportHandler
    {
        public HashSet<string> Namespaces { get; }

        public override bool IsEmpty => Namespaces.Count == 0;

        public ImportHandler()
        {
            Namespaces = new HashSet<string>();
        }

        public void AddImport(string @namespace)
        {
            Namespaces.Add(@namespace);
        }
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

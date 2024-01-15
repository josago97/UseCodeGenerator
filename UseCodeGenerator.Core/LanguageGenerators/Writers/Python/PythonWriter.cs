using System.Reflection.Metadata;
using UseCodeGenerator.Core.LanguageGenerators.Entities;
using UseCodeGenerator.Utilities;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers.Python;

internal class PythonWriter : LanguageWriter<PythonOptions>
{
    private const string FILE_EXTENSION = "py";

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
            builder.WriteLine();
        }

        builder.WriteLine(classText);
    }

    private void WriteClass(LClass @class, CodeBuilder builder)
    {
        WriteClassHeader(@class, builder);

        builder.WriteLine(":");
        builder.AddTab();

        CodeBuilder bodyBuilder = CreateCodeBuilder();
        WriteClassBody(@class, bodyBuilder);
        string bodyText = bodyBuilder.ToStringWithTrim();
        builder.WriteLine(bodyText);

        builder.RemoveTab();
    }

    private void WriteClassHeader(LClass @class, CodeBuilder builder)
    {
        List<string> parents = new List<string>(@class.Parents.Select(s => s.ToPascalCase()));

        if (@class.IsAbstract)
        {
            _imports.AddImport("abc", "ABC");
            parents.Add("ABC");
        }

        string className = @class.Name.ToPascalCase();
        builder.Write($"class {className}");

        if (@class.Parents.Length > 0)
        {
            builder.Write($"({string.Join(", ", parents)})");
        }
    }

    private void WriteClassBody(LClass @class, CodeBuilder builder)
    {
        bool hasContent = false;

        if (@class.Attributes.Length > 0)
        {
            hasContent = true;

            WriteConstructor(@class, builder);
        }

        if (@class.Methods.Length > 0)
        {
            hasContent = true;

            builder.WriteLine();
            WriteMethods(@class.Methods, builder);
        }

        if (!hasContent)
        {
            builder.WriteLine("pass");
        }
    }

    private void WriteConstructor(LClass @class, CodeBuilder builder)
    {
        if (@class.IsAbstract)
        {
            _imports.AddImport("abc", "abstractmethod");
            builder.WriteLine("@abstractmethod");
        }

        AttributeInfo[] attributes = @class.Attributes.Select(a => new AttributeInfo
        (
            Name: a.Name.ToSnakeCase(),
            Type: a.Type,
            InitValue: GetInitValueText(a)
        ))
        .ToArray();

        // Write constructor header
        WriteMethodHeader("__init__", null, attributes, builder);

        builder.AddTab();

        // Write constructor body
        foreach (AttributeInfo attribute in attributes)
        {
            builder.Write($"self.{attribute.Name} = {attribute.Name}");

            if (attribute.IsCollection)
            {
                builder.Write(" or []");
            }

            builder.WriteLine();
        }

        builder.RemoveTab();
    }

    private void WriteMethods(IEnumerable<LMethod> methods, CodeBuilder builder)
    {
        foreach (LMethod method in methods)
        {
            string name = method.Name.ToSnakeCase();
            ParameterInfo[] parameters = method.Parameters.Select(a => new ParameterInfo
            (
                Name: a.Name.ToSnakeCase(),
                Type: a.Type
            ))
            .ToArray();

            WriteMethodHeader(name, method.ReturnType, parameters, builder);

            builder.AddTab();
            builder.WriteLine("pass");
            builder.RemoveTab();
            builder.WriteLine();
        }
    }

    private void WriteMethodHeader(string name, LType returnType, ParameterInfo[] parameters, CodeBuilder builder)
    {
        builder.Write($"def {name}(self");

        // Write parameters
        foreach (ParameterInfo parameter in parameters)
        {
            string defaultValue = parameter.InitValue;

            builder.Write($", {parameter.Name}");

            if (Options.EnableTypeHinting)
            {
                string typeName = GetTypeName(parameter.Type);
                builder.Write($": {typeName}");

                if (string.IsNullOrEmpty(defaultValue))
                {
                    builder.Write(" | None");
                }
            }

            if (!string.IsNullOrEmpty(defaultValue))
            {
                builder.Write($" = {defaultValue}");
            }
        }

        builder.Write(")");

        if (Options.EnableTypeHinting)
        {
            string returnTypeName = GetReturnTypeName(returnType);
            builder.Write($" -> {returnTypeName}");
        }

        builder.WriteLine(":");
    }

    private string GetReturnTypeName(LType type)
    {
        return type switch
        {
            null => "None",
            _ => GetTypeName(type)
        };
    }

    #endregion

    protected override void MakeEnumeration(LEnumeration enumeration, CodeBuilder builder)
    {
        _imports = new ImportHandler();

        CodeBuilder enumerationBuilder = CreateCodeBuilder();
        WriteEnumeration(enumeration, enumerationBuilder);
        string enumerationText = enumerationBuilder.ToStringWithTrim();

        CodeBuilder importsBuilder = CreateCodeBuilder();
        WriteImports(importsBuilder);
        string importsText = importsBuilder.ToStringWithTrim();

        builder.WriteLine(importsText);
        builder.WriteLine();
        builder.WriteLine();
        builder.WriteLine(enumerationText);
    }

    private void WriteEnumeration(LEnumeration enumeration, CodeBuilder builder)
    {
        WriteEnumerationHeader(enumeration, builder);
        builder.AddTab();
        WriteEnumerationValues(enumeration, builder);
        builder.RemoveTab();
    }

    private void WriteEnumerationHeader(LEnumeration enumeration, CodeBuilder builder)
    {
        _imports.AddImport("enum", "Enum");

        string name = enumeration.Name.ToPascalCase();
        builder.WriteLine($"class {name}(Enum):");
    }

    private void WriteEnumerationValues(LEnumeration enumeration, CodeBuilder builder)
    {
        if (enumeration.Values.Length == 0)
        {
            builder.WriteLine("pass");
        }
        else
        {
            _imports.AddImport("enum", "auto");

            foreach (string value in enumeration.Values)
            {
                string valueName = value.ToUpperSnakeCase();
                builder.WriteLine($"{valueName} = auto()");
            }
        }
    }

    #region Common

    protected override string GetFileName(LCustomType customType)
    {
        return customType.Name.ToSnakeCase();
    }

    private void WriteImports(CodeBuilder builder)
    {
        foreach (var dependency in _imports.Dependencies)
        {
            string module = dependency.Key;
            string items = string.Join(", ", dependency.Value);

            builder.WriteLine($"from {module} import {items}");
        }
    }

    private string GetTypeName(LType type)
    {
        string typeName = type switch
        {
            LPrimitiveType primitive => primitive.Type switch
            {
                LPrimitiveType.Kind.Boolean => "bool",
                LPrimitiveType.Kind.Integer => "int",
                LPrimitiveType.Kind.Real => "float",
                LPrimitiveType.Kind.String => "str",
                _ => throw new Exception($"Unknown type {type}")
            },
            LCustomType custom => custom.Name,
            LCollectionType collection => $"list[{GetTypeName(collection.Type)}]",
            _ => "Any"
        };

        if (type is LCustomType customType)
        {
            _imports.AddImport(GetFileName(customType), typeName);
        }
        else if (typeName == "Any")
        {
            _imports.AddImport("typing", "Any");
        }

        return typeName;
    }

    private string GetInitValueText(LAttribute attribute)
    {
        string result = null;
        LType type = attribute.Type;
        object initValue = attribute.InitValue;

        if (initValue != null && type is not LCollectionType)
        {
            result = initValue switch
            {
                true => "True",
                false => "False",
                int or double => "0",
                string => $"'{initValue}'",
                _ => initValue.ToString()
            };
        }

        return result;
    }

    #endregion

    private record ParameterInfo(string Name, LType Type, string InitValue = null);

    private record AttributeInfo(string Name, LType Type, string InitValue)
        : ParameterInfo(Name, Type, InitValue)
    {
        public bool IsCollection => Type is LCollectionType;
    }

    private class ImportHandler : BaseImportHandler
    {
        public Dictionary<string, HashSet<string>> Dependencies { get; }

        public override bool IsEmpty => Dependencies.Count == 0;

        public ImportHandler()
        {
            Dependencies = new Dictionary<string, HashSet<string>>();
        }

        public void AddImport(string module, params string[] items)
        {
            HashSet<string> modulesSet;

            if (!Dependencies.TryGetValue(module, out modulesSet))
            {
                modulesSet = new HashSet<string>();
                Dependencies.Add(module, modulesSet);
            }

            foreach (string item in items)
            {
                modulesSet.Add(item);
            }
        }
    }
}

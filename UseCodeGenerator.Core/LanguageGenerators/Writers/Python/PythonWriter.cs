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

        WriteClassBody(@class, builder);

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
        CodeBuilder constructorBuilder = CreateCodeBuilder();
        WriteConstructor(@class, constructorBuilder);
        string constructorText = constructorBuilder.ToStringWithTrim();

        CodeBuilder methodsBuilder = CreateCodeBuilder();
        WriteMethods(@class.Methods, methodsBuilder);
        string methodsText = methodsBuilder.ToStringWithTrim();

        if (!string.IsNullOrEmpty(constructorText))
        {
            builder.WriteLine(constructorText);
        }

        if (!string.IsNullOrEmpty(methodsText))
        {
            builder.WriteLine();
            builder.WriteLine(methodsText);
        }
    }

    private void WriteConstructor(LClass @class, CodeBuilder builder)
    {
        if (@class.IsAbstract)
        {
            _imports.AddImport("abc", "abstractmethod");
            builder.WriteLine("@abstractmethod");
        }

        builder.WriteLine("def __init__(self) -> None:");
        builder.AddTab();

        if (@class.Attributes.Length == 0)
        {
            builder.WriteLine("pass");
        }
        else
        {
            foreach (LAttribute attribute in @class.Attributes)
            {
                string name = attribute.Name.ToSnakeCase();
                string type = GetReturnTypeName(attribute.Type);
                string initValue = GetInitValueText(attribute);

                builder.Write($"self.{name}: {type}");

                if (string.IsNullOrEmpty(initValue))
                {
                    builder.WriteLine(" | None = None");
                }
                else
                {
                    builder.WriteLine($" = {initValue}");
                }
            }
        }

        builder.RemoveTab();
    }

    private void WriteMethods(IEnumerable<LMethod> methods, CodeBuilder builder)
    {
        foreach (LMethod method in methods)
        {
            string name = method.Name.ToSnakeCase();
            string returnType = GetReturnTypeName(method.ReturnType);
            string parameters = string.Join(", ", 
            [
                "self",
                .. method.Parameters.Select(p =>
                    $"{p.Name.ToSnakeCase()}: {GetTypeName(p.Type)}")
            ]);

            builder.WriteLine($"def {name}({parameters}) -> {returnType}:");
            builder.AddTab();
            builder.WriteLine("pass");
            builder.RemoveTab();
            builder.WriteLine();
        }
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

        if (type is LCollectionType)
        {
            result = "[]";
        }
        else if (initValue != null)
        {
            result = initValue switch
            {
                true => "True",
                false => "False",
                string => $"'{initValue}'",
                _ => initValue.ToString()
            };
        }

        return result;
    }

    #endregion

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

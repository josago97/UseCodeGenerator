using UseCodeGenerator.Core.LanguageGenerators.Entities;
using UseCodeGenerator.Utilities;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal class PythonWriter : LanguageWriter
{
    private const string FILE_EXTENSION = "py";

    protected override string FileExtension => FILE_EXTENSION;

    protected override void MakeClass(LClass @class, CodeBuilder builder)
    {
        WriteClassImports(@class, builder);
        builder.WriteLine();
        WriteClassHeader(@class, builder);
        builder.AddTab();
        WriteConstructor(@class, builder);
        builder.WriteLine();
        WriteMethods(@class.Methods, builder);
        builder.RemoveTab();
    }

    private void WriteClassImports(LClass @class, CodeBuilder builder)
    {
        if (@class.IsAbstract)
        {
            builder.WriteLine("from abc import ABC, abstractmethod");
        }
    }

    private void WriteClassHeader(LClass @class, CodeBuilder builder)
    {
        List<string> parents = new List<string>(@class.Parents.Select(s => s.ToPascalCase()));

        if (@class.IsAbstract)
        {
            parents.Add("ABC");
        }

        string className = @class.Name.ToPascalCase();
        builder.Write($"class {className}");

        if (@class.Parents.Length > 0)
        {
            builder.Write($"({string.Join(", ", parents)})");
        }

        builder.WriteLine(":");
    }

    private void WriteConstructor(LClass @class, CodeBuilder builder)
    {
        if (@class.IsAbstract)
        {
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

                builder.Write($"self.{name}: {type}");

                if(attribute.InitValue == null)
                {
                    builder.WriteLine(" | None = None");
                }
                else
                {
                    builder.WriteLine(" = {attribute.InitValue}");
                }
            }
        }

        builder.RemoveTab();
        /*"def __init__(self):";
            "self.atr1: type1 = valor"
            "self.atr2: type2 | None = None"*/
    }

    private void WriteMethods(IEnumerable<LMethod> methods, CodeBuilder builder)
    {
        foreach (LMethod method in methods)
        {
            string name = method.Name.ToSnakeCase();
            string returnType = GetReturnTypeName(method.ReturnType);
            string arguments = string.Join(", ",
                method.Parameters.Select(p =>
                $"{p.Name.ToSnakeCase()}: {GetTypeName(p.Type)}"));

            builder.WriteLine($"def {name}(self, {arguments}) -> {returnType}:");
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

    protected override void MakeEnumeration(LEnumeration enumeration, CodeBuilder builder)
    {
        WriteEnumerationImports(builder);
        builder.WriteLine();
        WriteEnumerationHeader(enumeration, builder);
        builder.AddTab();
        WriteEnumerationValues(enumeration, builder);
        builder.RemoveTab();
    }

    private void WriteEnumerationImports(CodeBuilder builder)
    {
        builder.WriteLine("from enum import Enum, auto");
    }

    private void WriteEnumerationHeader(LEnumeration enumeration, CodeBuilder builder)
    {
        string name = enumeration.Name.ToPascalCase();
        builder.WriteLine($"class {name}(Enum):");
    }

    private void WriteEnumerationValues(LEnumeration enumeration, CodeBuilder builder)
    {
        foreach (string value in enumeration.Values)
        {
            string valueName = value.ToUpperSnakeCase();
            builder.WriteLine($"{valueName} = auto()");
        }
    }

    private string GetTypeName(LType type)
    {
        return type switch
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
            _ => "Any" //"from typing import Any"
        };
    }

    protected override string GetFileName(ILTypeDefinition typeDefinition)
    {
        return typeDefinition.Name.ToSnakeCase();
    }
}

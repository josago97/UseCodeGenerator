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
        WriteConstructor(@class.Attributes, builder);
        builder.WriteLine();
        WriteMethods(@class.Methods, builder);
        builder.RemoveTab();
    }

    private void WriteClassImports(LClass @class, CodeBuilder builder)
    {
        if (@class.IsAbstract)
        {
            builder.WriteLine("from abc import ABC, ");
        }
    }

    private void WriteClassHeader(LClass @class, CodeBuilder builder)
    {
        List<string> parents = new List<string>(@class.Parents.Select(s => s.ToPascalCase()));

        if (@class.IsAbstract)
        {
            parents.Add("ABC");
        }

        builder.Write($"class {@class.Name.ToPascalCase()}");

        if (@class.Parents.Length > 0)
        {
            builder.Write($"({string.Join(", ", parents)})");
        }

        builder.WriteLine(":");
    }

    private void WriteConstructor(IList<LAttribute> attributtes, CodeBuilder builder)
    {
        builder.WriteLine("def __init__(self) -> None:");
        builder.AddTab();

        if (attributtes.Count == 0)
        {
            builder.WriteLine("pass");
        }
        else
        {
            foreach (LAttribute attribute in attributtes)
            {
                string name = attribute.Name.ToSnakeCase();

                builder.WriteLine($"self.{name} =");
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

            builder.WriteLine($"def {name}(self, atr1: str) -> returnType:");
            builder.AddTab();
            builder.WriteLine("pass");
            builder.RemoveTab();
        }
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
            builder.WriteLine($"{value.ToUpperSnakeCase()} = auto()");
        }
    }

    protected override string GetFileName(ILTypeDefinition typeDefinition)
    {
        return typeDefinition.Name.ToSnakeCase();
    }
}

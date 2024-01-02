using System.Reflection.Metadata.Ecma335;
using UseCodeGenerator.Core.LanguageGenerators.Entities;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal class CSharpWriter : LanguageWriter
{
    private const string CLASS = "class";
    private const string ABSTRACT = "abstract";
    private const string ENUM = "enum";

    protected override CodeFile MakeClass(LClass @class)
    {
        string classType = "class";

        if (@class.IsAbstract) classType = "abstract" + " " + classType;

        WriteNamespace();
        WriteLine($"public {classType} {@class.Name}");
        WriteLine("{");
        TabIndex++;
        //WriteLine(string.Join(",\n", enumeration.Values));
        TabIndex--;
        WriteLine("}");
        //WriteLine()

        throw new NotImplementedException();
    }

    protected override CodeFile MakeEnumeration(LEnumeration enumeration)
    {
        WriteNamespace();
        WriteLine($"public enum {enumeration.Name}");
        WriteLine("{");
        TabIndex++;
        WriteLine(string.Join(",\n", enumeration.Values));
        TabIndex--;
        WriteLine("}");

        return null;
    }

    private void WriteNamespace()
    {
        WriteLine($"namespace {Project.Name};");
    }

    private CodeFile GetCodeFile(string a)
    {
        return null;
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

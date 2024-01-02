using System.Text;
using UseCodeGenerator.Use.Entities;

namespace UseCodeGenerator.CodeGenerators;

public class JavaWriter : LanguageWriter
{
    public JavaWriter(UModel model) : base(model)
    {
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
                public {{attribute.Type}} get{{attribute.Name.ToPascalCase()}}()
                {
                {{TAB}}return {{attribute.Name}};
                }
                """;

            string setter = $$"""
                public {{attribute.Type}} set{{attribute.Name.ToPascalCase()}}({{attribute.Type}} {{attribute.Name}})
                {
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

    protected override CodeFile MakeClass(UClass @class)
    {
        throw new NotImplementedException();
    }

    protected override CodeFile MakeEnumeration(UEnumeration enumeration)
    {
        throw new NotImplementedException();
    }
}

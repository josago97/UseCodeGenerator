using UseCodeGenerator.Use.Entities;

namespace UseCodeGenerator.CodeGenerators;

public class LanguageWriterFactory
{
    public static LanguageWriter CreateWriter(UModel model, Language language)
    {
        return language switch
        {
            Language.CSharp => new CSharpWriter(model),
            //Language.Java => new JavaCodeGenerator(model),
            _ => throw new Exception($"Language {language} not supported"),
        };
    }
}

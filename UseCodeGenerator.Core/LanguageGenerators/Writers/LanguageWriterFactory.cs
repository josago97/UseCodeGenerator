namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal class LanguageWriterFactory
{
    public static LanguageWriter CreateWriter(Language language)
    {
        return language switch
        {
            Language.CSharp => new CSharpWriter(),
            Language.Java => new JavaWriter(),
            Language.Python => new PythonWriter(),
            _ => throw new Exception($"Language {language} not supported"),
        };
    }
}

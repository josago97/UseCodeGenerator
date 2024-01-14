using UseCodeGenerator.Core.LanguageGenerators.Writers.CSharp;
using UseCodeGenerator.Core.LanguageGenerators.Writers.Java;
using UseCodeGenerator.Core.LanguageGenerators.Writers.Python;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal class LanguageWriterFactory
{
    public static ILanguageWriter CreateWriter(Language language)
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

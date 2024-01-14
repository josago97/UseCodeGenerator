using UseCodeGenerator.Core.LanguageGenerators.Entities;
using UseCodeGenerator.Core.LanguageGenerators.Writers;
using UseCodeGenerator.Core.Use;
using UseCodeGenerator.Core.Use.Entities;

namespace UseCodeGenerator.Core;

public class CodeGenerator
{
    private UseReader UseReader { get; init; } = new UseReader();

    public CodeFile[] GenerateCode(string useCode, Language language, LanguageOptions options = null)
    {
        UModel useModel = UseReader.Read(useCode);

        //Thread.Sleep(50000);

        //throw new Exception();

        UseToLanguageConverter converter = new UseToLanguageConverter();
        LProject project = converter.Convert(useModel);

        ILanguageWriter languageWriter = LanguageWriterFactory.CreateWriter(language);
        CodeFile[] files = languageWriter.Generate(project);

        return files;
    }

    public Task<CodeFile[]> GenerateCodeAsync(string useCode, Language language)
    {
        return Task.Run(() => GenerateCode(useCode, language));
    }
}

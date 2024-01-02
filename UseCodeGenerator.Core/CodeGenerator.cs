using UseCodeGenerator.Core.LanguageGenerators;
using UseCodeGenerator.Core.LanguageGenerators.Writers;
using UseCodeGenerator.Core.Use;
using UseCodeGenerator.Core.Use.Entities;

namespace UseCodeGenerator.Core;

public class CodeGenerator
{
    private UseReader UseReader { get; init; } = new UseReader();

    public CodeFile[] GenerateCode(string useCode, Language language)
    {
        UModel useModel = UseReader.Read(useCode);

        LanguageWriter languageWriter = LanguageWriterFactory.CreateWriter(language);
        
    }

    public Task<CodeFile[]> GenerateCodeAsync(string useCode, Language language)
    {
        return Task.Run(() => GenerateCode(useCode, language));
    }
}

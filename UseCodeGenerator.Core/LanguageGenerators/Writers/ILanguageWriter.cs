using UseCodeGenerator.Core.LanguageGenerators.Entities;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal interface ILanguageWriter
{
    CodeFile[] Generate(LProject project);
}

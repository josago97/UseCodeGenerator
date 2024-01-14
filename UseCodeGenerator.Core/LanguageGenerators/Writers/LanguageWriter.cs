using UseCodeGenerator.Core.LanguageGenerators.Entities;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal abstract class LanguageWriter<TOptions> : ILanguageWriter where TOptions : LanguageOptions, new()
{
    public TOptions Options { get; set; } = new TOptions();
    protected abstract string FileExtension { get; }
    protected LProject Project { get; private set; }

    public CodeFile[] Generate(LProject project)
    {
        Project = project;
        CodeBuilder codeBuilder = CreateCodeBuilder();
        CodeFile[] files =
        [
            .. GenerateFiles(Project.Classes, codeBuilder, MakeClass),
            .. GenerateFiles(Project.Enumerations, codeBuilder, MakeEnumeration),
        ];

        return files;
    }

    private IEnumerable<CodeFile> GenerateFiles<T>(
        IEnumerable<T> typeDefinitons, 
        CodeBuilder builder, 
        Action<T, CodeBuilder> action)
        where T : LCustomType
    {
        foreach (T typeDefinition in typeDefinitons)
        {
            builder.Clear();
            string fileName = GetFileName(typeDefinition);
            action(typeDefinition, builder);

            yield return new CodeFile(fileName, FileExtension, builder.ToString());
        }
    }

    protected virtual CodeBuilder CreateCodeBuilder()
    {
        return new CodeBuilder(Options.Tab);
    }

    protected abstract void MakeClass(LClass @class, CodeBuilder builder);
    protected abstract void MakeEnumeration(LEnumeration enumeration, CodeBuilder builder);
    protected abstract string GetFileName(LCustomType customType);

    protected abstract class BaseImportHandler
    {
        public abstract bool IsEmpty { get; }
    }
}

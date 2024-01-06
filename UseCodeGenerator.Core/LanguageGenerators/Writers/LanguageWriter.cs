using UseCodeGenerator.Core.LanguageGenerators.Entities;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal abstract class LanguageWriter
{
    protected static readonly string TAB = new string(' ', 4);

    protected abstract string FileExtension { get; }
    protected LProject Project { get; private set; }

    public CodeFile[] Generate(LProject project)
    {
        Project = project;
        List<CodeFile> files = new List<CodeFile>();
        CodeBuilder builder = new CodeBuilder(TAB);

        files.AddRange(GenerateFiles(Project.Classes, builder, MakeClass));
        files.AddRange(GenerateFiles(Project.Enumerations, builder, MakeEnumeration));

        return files.ToArray();
    }

    private IEnumerable<CodeFile> GenerateFiles<T>(
        IEnumerable<T> typeDefinitons,
        CodeBuilder builder,
        Action<T, CodeBuilder> action)
        where T : ILTypeDefinition
    {
        /*Parallel.ForAsync(0, 5, () =>
        {

        });*/

        foreach (T typeDefinition in typeDefinitons)
        {
            builder.Clear();
            action(typeDefinition, builder);

            yield return new CodeFile(GetFileName(typeDefinition), FileExtension, builder.ToString());
        }
    }

    protected abstract void MakeClass(LClass @class, CodeBuilder builder);
    protected abstract void MakeEnumeration(LEnumeration enumeration, CodeBuilder builder);
    protected abstract string GetFileName(ILTypeDefinition typeDefinition);
}

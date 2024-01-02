using System.Text;
using UseCodeGenerator.Core.LanguageGenerators.Entities;

namespace UseCodeGenerator.Core.LanguageGenerators.Writers;

internal abstract class LanguageWriter
{
    protected static readonly string TAB = new string(' ', 4);

    protected int TabIndex { get; set; }
    protected LProject Project { get; }
    private StringBuilder StringBuilder { get; set; }

    public IList<CodeFile> Generate(LProject Project)
    {
        List<CodeFile> files = new List<CodeFile>();
        StringBuilder = new StringBuilder();
        TabIndex = 0;

        foreach (LClass @class in Project.Classes)
        {
            files.Add(MakeClass(@class));
            StringBuilder.Clear();
        }

        foreach (LEnumeration enumeration in Project.Enumerations)
        {
            files.Add(MakeEnumeration(enumeration));
            StringBuilder.Clear();
        }

        return files;
    }

    public void Generate(LProject Project, string outputFolder)
    {
        Directory.CreateDirectory(outputFolder);
        IList<CodeFile> files = Generate(Project);

        foreach (CodeFile file in files)
        {
            File.WriteAllText($"{outputFolder}/{file.FullName}", file.Content);
        }
    }

    protected void WriteLine(string text)
    {
        for (int i = 0; i < TabIndex; i++)
            StringBuilder.Append(TAB);

        StringBuilder.AppendLine(text);
    }

    protected abstract CodeFile MakeClass(LClass @class);
    protected virtual void WriteAttributes() { }

    protected abstract CodeFile MakeEnumeration(LEnumeration enumeration);
}

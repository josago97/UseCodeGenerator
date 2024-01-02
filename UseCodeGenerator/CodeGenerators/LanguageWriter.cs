using System.Text;
using UseCodeGenerator.Use.Entities;

namespace UseCodeGenerator.CodeGenerators;

public abstract class LanguageWriter
{
    protected static readonly string TAB = new string(' ', 4);

    public UModel Model { get; }
    protected int TabIndex { get; private set; }
    private StringBuilder StringBuilder { get; set; }
    

    public LanguageWriter(UModel model)
    {
        Model = model;
    }

    public IList<CodeFile> Generate()
    {
        List<CodeFile> files = new List<CodeFile>();
        StringBuilder = new StringBuilder();
        TabIndex = 0;

        foreach (UClass @class in Model.Classes.Values)
        {
            files.Add(MakeClass(@class));
        }

        foreach (UEnumeration enumeration in Model.Enumerations.Values)
        {
            files.Add(MakeEnumeration(enumeration));
        }

        return files;
    }

    public void Generate(string outputFolder)
    {
        Directory.CreateDirectory(outputFolder);
        IList<CodeFile> files = Generate();

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

    protected abstract CodeFile MakeClass(UClass @class);
    protected virtual void WriteAttributes() { }

    protected abstract CodeFile MakeEnumeration(UEnumeration enumeration);
}

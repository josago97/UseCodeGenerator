namespace UseCodeGenerator.CodeGenerators;

public class CodeFile
{
    public string Name { get; }
    public string FullName { get; }
    public string Extension { get; }
    public string Content { get; }

    public CodeFile(string name, string extension, string content)
    {
        Name = name;
        Extension = extension;
        Content = content;
        FullName = $"{name}.{extension}";
    }
}

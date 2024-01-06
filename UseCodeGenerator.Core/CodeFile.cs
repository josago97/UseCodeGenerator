namespace UseCodeGenerator.Core;

public record CodeFile(string Name, string Extension, string Content)
{
    public string FullName { get; } = $"{Name}.{Extension}";
}

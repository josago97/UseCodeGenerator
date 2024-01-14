namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal record LClass(string Name) : LCustomType(Name)
{
    public bool IsAbstract { get; set; }
    public string[] Parents { get; set; }
    public LAttribute[] Attributes { get; set; }
    public LMethod[] Methods { get; set; }
}

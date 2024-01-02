namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal class LClass : LType
{
    public string Name { get; init; }
    public bool IsAbstract { get; init; }
    public IEnumerable<string> Parents { get; init; }
    public IEnumerable<LAttribute> Attributes { get; init; }
}

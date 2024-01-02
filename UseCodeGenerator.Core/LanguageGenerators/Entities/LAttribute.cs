namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal class LAttribute
{
    public string Name { get; init; }
    public LType Type { get; init; }
    public object InitValue { get; init; }
}

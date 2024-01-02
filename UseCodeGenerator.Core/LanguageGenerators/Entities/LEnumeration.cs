namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal class LEnumeration : LType
{
    public string Name { get; init; }
    public IEnumerable<string> Values { get; init; }
}

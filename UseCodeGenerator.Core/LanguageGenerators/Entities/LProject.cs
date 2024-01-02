namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal class LProject
{
    public string Name { get; init; }
    public IEnumerable<LClass> Classes { get; init; }
    public IEnumerable<LEnumeration> Enumerations { get; init; }
}

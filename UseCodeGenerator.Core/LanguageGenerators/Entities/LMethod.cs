namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal record LMethod(
    string Name, 
    IEnumerable<LParameter> Parameters, 
    LType ReturnType)
{
}

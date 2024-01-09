namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal record LMethod(
    string Name, 
    LParameter[] Parameters, 
    LType ReturnType)
{
}

namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal record LClass(
    string Name,
    bool IsAbstract,
    string[] Parents,
    LAttribute[] Attributes,
    LMethod[] Methods) : ILTypeDefinition
{
}

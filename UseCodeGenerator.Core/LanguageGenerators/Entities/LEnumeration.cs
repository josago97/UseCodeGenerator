namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal record LEnumeration(string Name, IEnumerable<string> Values) : ILTypeDefinition
{
}

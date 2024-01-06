namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal record LAttribute(string Name, LType Type, object InitValue = null)
{
}

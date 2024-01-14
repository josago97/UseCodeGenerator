namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal record LEnumeration(string Name, string[] Values) : LCustomType(Name)
{
}

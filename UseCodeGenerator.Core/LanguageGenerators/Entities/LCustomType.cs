namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal record LCustomType(string Name, LCustomType.Kind Type) : LType
{
    public enum Kind
    {
        Class,
        Enumeration
    }
}

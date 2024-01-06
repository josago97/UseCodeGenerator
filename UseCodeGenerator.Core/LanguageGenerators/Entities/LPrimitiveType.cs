namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal record LPrimitiveType(LPrimitiveType.Kind Type) : LType
{
    public enum Kind
    {
        Boolean,
        Integer,
        Real,
        String
    }
}

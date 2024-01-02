namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal class LPrimitiveType : LType
{
    public enum Kind
    {
        Boolean,
        Integer,
        Real,
        String
    }

    public Kind Type { get; set; }
}

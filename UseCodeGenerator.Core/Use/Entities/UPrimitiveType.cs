namespace UseCodeGenerator.Core.Use.Entities;

internal class UPrimitiveType : UType
{
    public enum Kind
    {
        Boolean,
        Integer,
        Real,
        String
    }

    public Kind Type { get; set; }

    public UPrimitiveType(Kind type) : base(type.ToString())
    {
        Type = type;
    }
}

namespace UseCodeGenerator.Use.Entities;

public class UAttribute : UElement
{
    public UType Type { get; set; }
    public string InitValue { get; set; }

    public UAttribute() { }

    public UAttribute(string name, UType type, string initValue) : base(name)
    {
        Type = type;
        InitValue = initValue;
    }
}

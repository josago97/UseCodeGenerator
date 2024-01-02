namespace UseCodeGenerator.Use.Entities;

public class UEnumeration : UType
{
    public List<string> Values { get; }

    public UEnumeration(string name) : base(name)
    {
        Values = new List<string>();
    }

    public UEnumeration(string name, IEnumerable<string> values) : this(name)
    {
        Values.AddRange(values);
    }
}

namespace UseCodeGenerator.Core.Use.Entities;

internal class UOperation : UElement
{
    public UType ReturnType { get; set; }
    public HashSet<UParameter> Parameters { get; init; }

    public UOperation(string name) : base(name) 
    {
        Parameters = new HashSet<UParameter>();
    }

    public UOperation(string name, UType returnType) : this(name)
    {
        ReturnType = returnType;
    }
}

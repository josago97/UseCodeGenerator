namespace UseCodeGenerator.Core.Use.Entities;

internal class UClass : UType
{
    public bool IsAbstract { get; set; }
    public HashSet<UClass> Parents { get; }
    public HashSet<UAttribute> Attributes { get; }
    public HashSet<UOperation> Operations { get; }

    public UClass(string name, bool isAbstract) : base(name)
    {
        IsAbstract = isAbstract;
        Parents = new HashSet<UClass>();
        Attributes = new HashSet<UAttribute>();
        Operations = new HashSet<UOperation>();
    }

    public void AddAttribute(UAttribute attribute)
    {
        if (!Attributes.Add(attribute))
            throw new Exception($"Duplicate attribute \"{attribute}\" in {Name} class");
    }

    public void AddOperation(UOperation operation)
    {
        if (!Operations.Add(operation))
            throw new Exception($"Duplicate operation \"{operation}\" in {Name} class");
    }

    public void AddParent(UClass @class)
    {
        if (!Parents.Add(@class))
            throw new Exception($"Duplicate parent \"{@class}\" in {Name} class");
    }

    public override bool Equals(object? obj)
    {
        string otherName = (obj as UClass)?.Name;

        return Name == otherName;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}

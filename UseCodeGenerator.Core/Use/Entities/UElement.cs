namespace UseCodeGenerator.Core.Use.Entities;

internal abstract class UElement
{
    private int _hashCode;
    private string _name;

    public virtual string Name 
    {
        get =>_name;
        set
        {
            _name = value;
            _hashCode = _name.GetHashCode();
        }
    }

    public UElement() { }

    public UElement(string name)
    {
        Name = name;
    }

    public override bool Equals(object? obj)
    {
        bool result = false;

        if (ReferenceEquals(this, obj))
        {
            result = true;
        }
        else if (GetType() == obj?.GetType())
        {
            if (_hashCode == obj.GetHashCode())
            {
                result = true;
            }
            else if (obj is UElement element)
            {
                result = Name.Equals(element.Name);
            }
        }

        return result;
    }

    public override int GetHashCode()
    {
        return _hashCode;
    }

    public override string ToString()
    {
        return Name;
    }
}
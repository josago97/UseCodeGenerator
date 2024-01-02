namespace UseCodeGenerator.Core.Use.Entities;

internal class UAssociation: UElement
{
    public List<Item> Items { get; set; }

    public UAssociation(string name) : base(name) 
    {
        Items = new List<Item>();
    }

    public class Item
    {
        public string Class { get; set; }
        public Multiplicity Multiplicity { get; set; }
        public string Role { get; set; }
    }

    public class Multiplicity
    {
        public bool IsRange { get; init; }
        public int Min { get; init; }
        public int Max { get; init; }

        public Multiplicity(int min, int max)
        {
            Min = min;
            Max = max;
            IsRange = Min != Max;
        }

        public Multiplicity(int multiplicity) : this(multiplicity, multiplicity)
        {
        }
    }
}

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
        public string ClassName { get; set; }
        public Multiplicity Multiplicity { get; set; }
        public string Role { get; set; }
    }

    public class Multiplicity
    {
        public const int Infinity = int.MaxValue;

        public bool IsCollection { get; init; }
        public int Min { get; init; }
        public int Max { get; init; }

        public Multiplicity(int min, int max)
        {
            Min = min;
            Max = max;
            IsCollection = Max > 1;
        }

        public Multiplicity(int multiplicity) : this(multiplicity, multiplicity)
        {
        }
    }
}

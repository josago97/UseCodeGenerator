namespace UseCodeGenerator.Core.Use.Entities;

internal class UModel
{
    public string Name { get; set; }
    public Dictionary<string, UClass> Classes { get; }
    public Dictionary<string, UEnumeration> Enumerations { get; }
    public Dictionary<string, UAssociation> Associations { get; }

    public UModel(string name)
    {
        Name = name;

        Classes = new Dictionary<string, UClass>();
        Enumerations = new Dictionary<string, UEnumeration>();
        Associations = new Dictionary<string, UAssociation>();
    }

    public void AddClass(UClass @class)
    {
        Add(@class, Classes, "class");
    }

    public void AddEnumeration(UEnumeration @enum)
    {
        Add(@enum, Enumerations, "enumeration");
    }

    public void AddAssociation(UAssociation association)
    {
        Add(association, Associations, "association");
    }

    private void Add<T>(T element, Dictionary<string, T> dictionary, string elementName)
        where T : UElement
    {
        string name = element.Name;

        if (!dictionary.TryAdd(name, element))
            throw new Exception($"{name} {elementName} already exists");
    }

    public UType FindType(string name)
    {
        UType type = null;

        if (Classes.TryGetValue(name, out UClass @class))
        {
            type = @class;
        }
        else if (Enumerations.TryGetValue(name, out UEnumeration @enum))
        {
            type = @enum;
        }

        return type;
    }
}

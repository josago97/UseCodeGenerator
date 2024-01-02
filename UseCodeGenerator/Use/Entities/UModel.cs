using System.Collections.Generic;
using UseCodeGenerator.Use.Entities;

namespace UseCodeGenerator.Use.Entities;

public class UModel
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
        string name = @class.Name;

        if (!Classes.TryAdd(name, @class))
            throw new Exception($"{name} class already exists");
    }

    public void AddEnumeration(UEnumeration @enum)
    {
        string name = @enum.Name;

        if (!Enumerations.TryAdd(name, @enum))
            throw new Exception($"{name} enumeration already exists");
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

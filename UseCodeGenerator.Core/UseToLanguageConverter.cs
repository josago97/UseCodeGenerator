using UseCodeGenerator.Core.LanguageGenerators.Entities;
using UseCodeGenerator.Core.Use.Entities;

namespace UseCodeGenerator.Core;

internal class UseToLanguageConverter
{
    public LProject Convert(UModel model)
    {
        LProject project = new LProject()
        {
            Name = model.Name,
            Classes = GetClasses(model)
        };

        return project;
    }

    private IEnumerable<LClass> GetClasses(UModel model)
    {
        List<LClass> classes = new List<LClass>();
        IEnumerable<UAssociation> uAssociations = model.Associations.Values;

        foreach (UClass uClass in model.Classes.Values)
        {
            LClass lClass = new LClass()
            {
                Name = uClass.Name,
                IsAbstract = uClass.IsAbstract,
                Parents = uClass.Parents.Select(c => c.Name),
                Attributes = GetAttributes(uClass.Attributes)
            };

            classes.Add(lClass);
        }

        return classes;
    }

    private IEnumerable<LAttribute> GetAttributes(IEnumerable<UAttribute> uAttributes) 
    {
        UModel model = null;

        model.Associations.Values.SelectMany(association => association.Items)
            .Where(item => item.Class == "");
    }
}

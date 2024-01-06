using UseCodeGenerator.Core.LanguageGenerators.Entities;
using UseCodeGenerator.Core.Use.Entities;

namespace UseCodeGenerator.Core;

internal class UseToLanguageConverter
{
    public LProject Convert(UModel model)
    {
        LProject project = new LProject(
            Name: model.Name,
            Classes: GetClasses(model).ToArray(),
            Enumerations: GetEnumerations(model).ToArray()
        );

        return project;
    }

    private IEnumerable<LEnumeration> GetEnumerations(UModel model)
    {
        foreach (UEnumeration uEnum in model.Enumerations.Values)
        {
            LEnumeration lEnumeration = new LEnumeration(
                Name: uEnum.Name,
                Values: uEnum.Values
            );

            yield return lEnumeration;
        }
    }

    private IEnumerable<LClass> GetClasses(UModel model)
    {
        IEnumerable<UAssociation> uAllAssociations = model.Associations.Values;

        foreach (UClass uClass in model.Classes.Values)
        {
            string className = uClass.Name;
            IEnumerable<UAssociation.Item> uAssociationItems = GetAssociationItems(className, uAllAssociations);

            LClass lClass = new LClass(
                Name: className,
                IsAbstract: uClass.IsAbstract,
                Parents: uClass.Parents.Select(c => c.Name).ToArray(),
                Attributes: GetAttributes(uClass.Attributes, uAssociationItems).ToArray(),
                Methods: GetMethods(uClass.Operations).ToArray()
            );

            yield return lClass;
        }
    }

    private IEnumerable<LAttribute> GetAttributes(IEnumerable<UAttribute> uAttributes, 
        IEnumerable<UAssociation.Item> uAssociationItems)
    {
        foreach (UAttribute uAttribute in uAttributes)
        {
            LAttribute lAttribute = new LAttribute(
                Name: uAttribute.Name,
                Type: GetType(uAttribute.Type),
                InitValue: uAttribute.InitValue
            );

            yield return lAttribute;
        }

        foreach (UAssociation.Item uAssociationItem in uAssociationItems)
        {
            LAttribute lAttribute = new LAttribute(
                Name: uAssociationItem.Role,
                Type: GetType(uAssociationItem)
            );

            yield return lAttribute;
        }
    }

    private IEnumerable<UAssociation.Item> GetAssociationItems(string className, 
        IEnumerable<UAssociation> associations)
    {
        foreach (UAssociation association in associations)
        {
            if (association.Items[0].Class == className)
            {
                yield return association.Items[1];
            }
            else if (association.Items[1].Class == className)
            {
                yield return association.Items[0];
            }
        }
    }

    private IEnumerable<LMethod> GetMethods(IEnumerable<UOperation> uOperations)
    {
        foreach (UOperation uOperation in uOperations)
        {
            LMethod lMethod = new LMethod(
                Name: uOperation.Name,
                ReturnType: null,
                Parameters: null
            );

            yield return lMethod;
        }
    }

    private LType GetType(UType uType)
    {
        return uType switch
        {
            UPrimitiveType primitive => new LPrimitiveType((LPrimitiveType.Kind)primitive.Type),
            UClass => new LCustomType(uType.Name, LCustomType.Kind.Class),
            UEnumeration => new LCustomType(uType.Name, LCustomType.Kind.Enumeration),
            _ => null
        };
    }

    private LType GetType(UAssociation.Item uAssociationItem)
    {
        LCustomType classType = new LCustomType(uAssociationItem.Class, LCustomType.Kind.Class);

        return uAssociationItem.Multiplicity.IsCollection
            ? new LCollectionType(classType)
            : classType;
    }
}

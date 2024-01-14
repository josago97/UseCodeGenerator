using UseCodeGenerator.Core.LanguageGenerators.Entities;
using UseCodeGenerator.Core.Use.Entities;

namespace UseCodeGenerator.Core;

internal class UseToLanguageConverter
{
    private Dictionary<string, LClass> _allClasses;
    private Dictionary<string, LEnumeration> _allEnumerations;

    public LProject Convert(UModel model)
    {
        _allClasses = new Dictionary<string, LClass>();
        _allEnumerations = new Dictionary<string, LEnumeration>();

        LProject project = new LProject(
            Name: model.Name,
            Enumerations: GetEnumerations(model).ToArray(),
            Classes: GetEmptyClasses(model).ToArray()
        );

        FillClassesInDepth(model);

        return project;
    }

    private IEnumerable<LEnumeration> GetEnumerations(UModel model)
    {
        foreach (UEnumeration uEnum in model.Enumerations.Values)
        {
            string enumName = uEnum.Name;

            LEnumeration lEnumeration = new LEnumeration(
                Name: enumName,
                Values: uEnum.Values.ToArray()
            );

            _allEnumerations.Add(enumName, lEnumeration);

            yield return lEnumeration;
        }
    }

    private IEnumerable<LClass> GetEmptyClasses(UModel model)
    {
        foreach (UClass uClass in model.Classes.Values)
        {
            string className = uClass.Name;

            LClass lClass = new LClass(className);

            _allClasses.Add(className, lClass);

            yield return lClass;
        }
    }

    private void FillClassesInDepth(UModel model)
    {
        IEnumerable<UAssociation> uAllAssociations = model.Associations.Values;

        foreach (string className in model.Classes.Keys)
        {
            UClass uClass = model.Classes[className];
            LClass lClass = _allClasses[className];
            IEnumerable<UAssociation.Item> uAssociationItems = GetAssociationItems(className, uAllAssociations);

            lClass.IsAbstract = uClass.IsAbstract;
            lClass.Parents = uClass.Parents.Select(c => c.Name).ToArray();
            lClass.Attributes = GetAttributes(uClass.Attributes, uAssociationItems).ToArray();
            lClass.Methods = GetMethods(uClass.Operations).ToArray();
        }
    }

    private IEnumerable<UAssociation.Item> GetAssociationItems(string className,
        IEnumerable<UAssociation> associations)
    {
        foreach (UAssociation association in associations)
        {
            if (association.Items[0].ClassName == className)
            {
                yield return association.Items[1];
            }
            else if (association.Items[1].ClassName == className)
            {
                yield return association.Items[0];
            }
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
                InitValue: GetInitValue(uAttribute)
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

    private object GetInitValue(UAttribute uAttribute)
    {
        object result = null;

        try
        {
            UType type = uAttribute.Type;
            string initValue = uAttribute.InitValue;

            if (!string.IsNullOrEmpty(initValue) && type is UPrimitiveType primitive)
            {
                result = primitive.Type switch
                {
                    UPrimitiveType.Kind.Real => double.Parse(initValue),
                    UPrimitiveType.Kind.Integer => int.Parse(initValue),
                    UPrimitiveType.Kind.Boolean => bool.Parse(initValue),
                    _ => initValue
                };
            }
        }
        catch (Exception ex)
        { }

        return result;
    }

    private IEnumerable<LMethod> GetMethods(IEnumerable<UOperation> uOperations)
    {
        foreach (UOperation uOperation in uOperations)
        {
            LMethod lMethod = new LMethod(
                Name: uOperation.Name,
                ReturnType: GetType(uOperation.ReturnType),
                Parameters: GetMethodParameters(uOperation.Parameters).ToArray()
            );

            yield return lMethod;
        }
    }

    private IEnumerable<LParameter> GetMethodParameters(IEnumerable<UParameter> uParameters)
    {
        foreach (UParameter uParameter in uParameters)
        {
            LParameter lParameter = new LParameter(
                Name: uParameter.Name,
                Type: GetType(uParameter.Type)
            );

            yield return lParameter;
        }
    }

    private LType GetType(UType uType)
    {
        return uType switch
        {
            UPrimitiveType primitive => new LPrimitiveType((LPrimitiveType.Kind)primitive.Type),
            UClass => _allClasses[uType.Name],
            UEnumeration => _allEnumerations[uType.Name],
            _ => null
        };
    }

    private LType GetType(UAssociation.Item uAssociationItem)
    {
        LCustomType classType = _allClasses[uAssociationItem.ClassName];

        return uAssociationItem.Multiplicity.IsCollection
            ? new LCollectionType(classType)
            : classType;
    }
}

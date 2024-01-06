namespace UseCodeGenerator.Core.LanguageGenerators.Entities;

internal record LProject(
    string Name, 
    LClass[] Classes, 
    LEnumeration[] Enumerations)
{
}

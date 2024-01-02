namespace UseCodeGenerator.Utilities;

public static class Extensions
{
    public static string ToCamelCase(this string text)
    {
        return string.IsNullOrWhiteSpace(text)
            ? string.Empty
            : char.ToLowerInvariant(text[0]) + text.Substring(1);
    }

    public static string ToPascalCase(this string text)
    {
        return string.IsNullOrWhiteSpace(text)
            ? string.Empty
            : char.ToUpperInvariant(text[0]) + text.Substring(1);
    }
}

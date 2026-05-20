using System.Text.RegularExpressions;

namespace MM.Domain.Shared.Extensions;

public static partial class StringExtensions
{
    public static string NormalizeSpaces(this string value)
    {
        return WhitespaceRegex().Replace(value.Trim(), " ");
    }
    
    [GeneratedRegex(@"\s+")]
    private static partial Regex WhitespaceRegex(); 
}
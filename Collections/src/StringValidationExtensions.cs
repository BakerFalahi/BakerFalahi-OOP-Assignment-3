using System.Text.RegularExpressions;

public static class StringValidationExtensions
{
    private static readonly Regex EgyptianPhonePattern = new(@"^(0(10|11|12|15)\d{8}|\+20(10|11|12|15)\d{8})$", RegexOptions.Compiled);
    private static readonly Regex EgyptianNationalIdPattern = new(@"^[23]\d{13}$", RegexOptions.Compiled);

    public static bool IsValidEgyptianPhone(this string? value)
    {
        return !string.IsNullOrWhiteSpace(value) && EgyptianPhonePattern.IsMatch(value);
    }

    public static bool IsValidEgyptianNationalId(this string? value)
    {
        return !string.IsNullOrWhiteSpace(value) && EgyptianNationalIdPattern.IsMatch(value);
    }
}

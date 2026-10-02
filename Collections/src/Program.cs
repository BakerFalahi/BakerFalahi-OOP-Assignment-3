var phoneCases = new[]
{
    new ValidationCase("01012345678", "IsValidEgyptianPhone", true, "010 prefix with 11 digits"),
    new ValidationCase("+201512345678", "IsValidEgyptianPhone", true, "+20 format with 015 prefix"),
    new ValidationCase("01312345678", "IsValidEgyptianPhone", false, "013 is not a valid prefix"),
    new ValidationCase("0101234567", "IsValidEgyptianPhone", false, "only 10 digits"),
    new ValidationCase("0101234567a", "IsValidEgyptianPhone", false, "contains a letter")
};

var nationalIdCases = new[]
{
    new ValidationCase("29901011234567", "IsValidEgyptianNationalId", true, "starts with 2 and has 14 digits"),
    new ValidationCase("19901011234567", "IsValidEgyptianNationalId", false, "must start with 2 or 3"),
    new ValidationCase("2990101123456", "IsValidEgyptianNationalId", false, "only 13 digits")
};

RunCases(phoneCases);
RunCases(nationalIdCases);

static void RunCases(IEnumerable<ValidationCase> cases)
{
    foreach (var testCase in cases)
    {
        var actual = testCase.MethodName == "IsValidEgyptianPhone"
            ? testCase.Value.IsValidEgyptianPhone()
            : testCase.Value.IsValidEgyptianNationalId();

        var result = actual == testCase.Expected ? "PASS" : "FAIL";
        Console.WriteLine($"{result} | {testCase.MethodName} | {testCase.Value} | expected: {testCase.Expected}, actual: {actual} | {testCase.Note}");
    }
}

internal sealed record ValidationCase(string Value, string MethodName, bool Expected, string Note);

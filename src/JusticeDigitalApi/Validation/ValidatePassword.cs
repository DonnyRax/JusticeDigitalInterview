using System.Text.RegularExpressions;

namespace JusticeDigitalApi.Validation;

internal sealed class ValidatePassword
{
    private readonly string _pattern = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[_]).{9,}$";

    public bool Validate(string passsword)
    {
		Regex tester = new(_pattern);
		
        var result = tester.IsMatch(passsword);

        return result;
    }
}

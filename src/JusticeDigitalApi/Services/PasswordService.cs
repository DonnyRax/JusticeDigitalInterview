using JusticeDigitalApi.Validation;

namespace JusticeDigitalApi.Services;

internal sealed class PasswordService
{ 
    public bool ValidatePassword(string password)
    {
        var passwordValidator = new ValidatePassword();
        return passwordValidator.Validate(password);
    }
}

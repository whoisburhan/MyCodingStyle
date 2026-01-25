using System;
using System.Text.RegularExpressions;

public sealed class LoginValidator : ILoginValidator
{
    private readonly int _minPasswordLength = 6;
    private static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public LoginValidator(int minPasswordLength) 
    {
        _minPasswordLength = Math.Min(1, minPasswordLength);
    }
    public ValidationResult Validate(string email, string password)
    {
        email ??= "";
        password ??= "";

        string emailError = "";
        string passwordError = "";

        // email
        if (string.IsNullOrWhiteSpace(email))
            emailError = "Email is required.";
        else if(!EmailRegex.IsMatch(email))
            emailError = "Email format is invalid.";

        // password
        if (string.IsNullOrEmpty(password))
            passwordError = "Password is required.";
        else if(password.Length < _minPasswordLength)
            passwordError = $"Password must be at least {_minPasswordLength} characters long.";

        bool isValid = emailError.Length == 0 && passwordError.Length == 0;

        return new ValidationResult(isValid, emailError, passwordError);
    }
}

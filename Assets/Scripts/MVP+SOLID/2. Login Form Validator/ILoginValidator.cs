public interface ILoginValidator
{
    ValidationResult Validate(string email, string password);
}

public readonly struct ValidationResult 
{
    public readonly bool IsValid;
    public readonly string EmailError;
    public readonly string PasswordError;

    public ValidationResult(bool isValid, string emailError, string passwordError)
    {
        IsValid = isValid;
        EmailError = emailError ?? "";
        PasswordError = passwordError ?? "";
    }
}

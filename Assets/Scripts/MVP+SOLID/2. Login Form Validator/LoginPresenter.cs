using NUnit.Framework.Internal.Commands;
using System;

public sealed class LoginPresenter
{
    private readonly ILoginView _view;
    private readonly ILoginValidator _validator;

    private string _email = "";
    private string _password = "";

    public LoginPresenter(ILoginView view, ILoginValidator validator)
    {
        _view = view;
        _validator = validator;

        _view.OnEmailChanged += HandleEmailChanged;
        _view.OnPasswordChanged += HandlePasswordChanged;
        _view.OnLoginClicked += HandleLoginClicked;

        _view.SetStatus("Ready");

        Refresh();
    }

    public void Dispose()
    {
        _view.OnEmailChanged -= HandleEmailChanged;
        _view.OnPasswordChanged -= HandlePasswordChanged;
        _view.OnLoginClicked -= HandleLoginClicked;
    }

    private void HandleEmailChanged(string email)
    {
        _email = email ?? "";
        Refresh();
    }

    private void HandlePasswordChanged(string password)
    {
        _password = password ?? "";
        Refresh();
    }

    private void HandleLoginClicked()
    {
        var result = _validator.Validate(_email, _password);
        Apply(result);

        if (result.IsValid)
            _view.SetStatus("Login successful");
        else
            _view.SetStatus("Login failed");
    }

    private void Refresh()
    {
        var result = _validator.Validate(_email, _password);
        Apply(result);
        _view.SetStatus("Ready");
    }

    private void Apply(ValidationResult result) 
    {
        _view.SetEmailError(result.EmailError);
        _view.SetPasswordError(result.PasswordError);
        _view.SetLoginInteractable(result.IsValid);
    }
}

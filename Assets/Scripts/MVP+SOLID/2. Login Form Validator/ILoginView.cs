using System;
using UnityEngine;

public interface ILoginView
{
    // view -> presenter input changes
    event Action<string> OnEmailChanged;
    event Action<string> OnPasswordChanged;
    event Action OnLoginClicked;

    // presenter -> view updates
    void SetEmailError(string error);
    void SetPasswordError(string error);
    void SetLoginInteractable(bool isInteractable);
    void SetStatus(string status);
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class LoginView : MonoBehaviour, ILoginView
{
    [Header("Input")]
    [SerializeField] private TMP_InputField emailInput;
    [SerializeField] private TMP_InputField passwordInput;

    [Header("Error")]
    [SerializeField] private TextMeshProUGUI emailErrorText;
    [SerializeField] private TextMeshProUGUI passwordErrorText;

    [Header("Action")]
    [SerializeField] private Button loginButton;

    [Header("Status")]
    [SerializeField] private TextMeshProUGUI statusText;

    public event Action<string> OnEmailChanged;
    public event Action<string> OnPasswordChanged;
    public event Action OnLoginClicked;

    private void Awake()
    {
        emailInput.onValueChanged.AddListener(v => OnEmailChanged?.Invoke(v));
        passwordInput.onValueChanged.AddListener(v => OnPasswordChanged?.Invoke(v));
        loginButton.onClick.AddListener(() => OnLoginClicked?.Invoke());
    }

    public void SetEmailError(string error)
    {
        emailErrorText.text = error;
        emailErrorText.gameObject.SetActive(!string.IsNullOrEmpty(error));
    }

    public void SetPasswordError(string error)
    {
        passwordErrorText.text = error;
        passwordErrorText.gameObject.SetActive(!string.IsNullOrEmpty(error));
    }

    public void SetLoginInteractable(bool isInteractable)
    {
        loginButton.interactable = isInteractable;
    }

    public void SetStatus(string status)
    {
        statusText.text = status;
    }
}

using UnityEngine;

public class LoginBootstrap : MonoBehaviour
{
    [SerializeField] private LoginView View;

    [Header("Rules")]
    [SerializeField] private int minPasswordLength = 6;

    private LoginPresenter _presenter;

    private void Start()
    {
        var validator = new LoginValidator(minPasswordLength);
        _presenter = new LoginPresenter(View, validator);
    }

    private void OnDestroy()
    {
        _presenter?.Dispose();
    }
}

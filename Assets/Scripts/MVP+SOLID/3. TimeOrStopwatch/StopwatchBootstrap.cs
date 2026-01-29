using UnityEngine;

public sealed class StopwatchBootstrap : MonoBehaviour
{
    [SerializeField] private StopwatchView view;

    private StopwatchPresenter _presenter;

    private void Start()
    {
        var model = new StopwatcModel();
        var formatter = new StopwatchTimeFormatter();
        _presenter = new StopwatchPresenter(view, model, formatter);
    }
    private void Update()
    {
        _presenter?.Tick(Time.deltaTime);
    }

    private void OnDestroy()
    {
        _presenter?.Dispose();
    }
}

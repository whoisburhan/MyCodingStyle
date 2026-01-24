using UnityEngine;

public class CounterBootstrap : MonoBehaviour
{
    [SerializeField] private CounterView view;

    [Header("Model Settings")]
    [SerializeField] private int min = 0;
    [SerializeField] private int max = 10;
    [SerializeField] private int startValue = 0;

    private CounterPresenter _presenter;

    private void Start()
    {
        var model = new CounterModel(min, max, startValue);
        _presenter = new CounterPresenter(model, view);
    }

    private void OnDestroy()
    {
        _presenter?.Dispose();
    }
}

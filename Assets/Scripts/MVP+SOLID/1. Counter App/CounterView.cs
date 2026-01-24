using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class CounterView : MonoBehaviour, ICounterView
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Button incrementButton;
    [SerializeField] private Button decrementButton;
    [SerializeField] private Button resetButton;

    public event Action OnIncrementClicked;
    public event Action OnDecrementClicked;
    public event Action OnResetClicked;

    private void Awake()
    {
        incrementButton.onClick.AddListener(() => OnIncrementClicked?.Invoke());
        decrementButton.onClick.AddListener(() => OnDecrementClicked?.Invoke());
        resetButton.onClick.AddListener(() => OnResetClicked?.Invoke());
    }

    public void SetCountText(string text)
    {
        countText.text = text;
    }

    public void SetIncrementInteractable(bool isOn)
    {
        incrementButton.interactable = isOn;
    }

    public void SetDecrementInteractable(bool isOn)
    {
        decrementButton.interactable = isOn;
    }
}

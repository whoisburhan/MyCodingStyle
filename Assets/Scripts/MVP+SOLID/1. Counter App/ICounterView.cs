using System;
using UnityEngine;

public interface ICounterView
{
    void SetCountText(string text);
    void SetIncrementInteractable(bool isOn);
    void SetDecrementInteractable(bool isOn);

    event Action OnIncrementClicked;
    event Action OnDecrementClicked;
    event Action OnResetClicked;
}

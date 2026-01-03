using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class RxInput : MonoBehaviour
{
    [SerializeField] TMP_InputField searchField;

    private float waitingDuration = 300;
    private void Start()
    {
        searchField.onValueChanged.AsObservable()
            .Throttle(TimeSpan.FromMilliseconds(waitingDuration))
            .Subscribe(text => Debug.Log($"User stopped typing: {text}"))
            .AddTo(this);
    }
}

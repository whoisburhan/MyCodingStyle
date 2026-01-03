using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class RxCoolDown : MonoBehaviour
{
    private Button fireButton;

    private void Awake()
    {
        fireButton = GetComponent<Button>();
    }

    private void Start()
    {
        fireButton.OnClickAsObservable()
            .ThrottleFirst(TimeSpan.FromSeconds(3))
            .Subscribe(_ => Debug.Log("Fire!"))
            .AddTo(this);
    }
}
    

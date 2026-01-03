using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class RxDoubleClick : MonoBehaviour
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        var clickStream = button.OnClickAsObservable();

        clickStream.Buffer(TimeSpan.FromMilliseconds(300),2)
            .Where(x => x.Count ==2)
            .Subscribe(_ => Debug.Log("Double Click Detected via Rx"))
            .AddTo(this);
    }
}

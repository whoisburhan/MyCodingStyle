
using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class DoubleClickDetector : MonoBehaviour
{
    private void Start()
    {
        var clickStream = this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0));

        clickStream.Buffer(clickStream.Throttle(TimeSpan.FromSeconds(0.25f)))
            .Where(x => x.Count >= 2)
            .Subscribe(_ => Debug.Log($"Double Click"));
    }
}

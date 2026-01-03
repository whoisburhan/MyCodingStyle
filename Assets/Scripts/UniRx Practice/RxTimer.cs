using UniRx;
using UnityEngine;

public class RxTimer : MonoBehaviour
{
    private void Start() 
    {
        Observable.Interval(System.TimeSpan.FromSeconds(1))
            .Subscribe(x => Debug.Log($"Timer Tick: {x}"))
            .AddTo(this);
    }
}

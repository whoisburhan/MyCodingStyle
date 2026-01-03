using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class RxButton : MonoBehaviour
{
    [SerializeField] Button button;

    private void Start()
    {
        var buttonStream = button.OnClickAsObservable()
            .Subscribe(_ => Debug.Log("Button Clicked"))
            .AddTo(this);
        
    }
}

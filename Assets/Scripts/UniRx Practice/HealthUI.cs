using TMPro;
using UnityEngine;
using UniRx;

public class HealthUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] ReactiveHealth health;

    private void Start()
    {
        health.Health.Subscribe(hp => 
        {
            hpText.text = $"HP: {hp}";
        }).AddTo(this);
    }

}

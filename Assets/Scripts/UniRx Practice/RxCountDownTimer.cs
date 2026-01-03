using System;
using TMPro;
using UniRx;
using UnityEngine;

public class RxCountDownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private int startSeconds = 30;

    private ReactiveProperty<int> remainingTime = new ReactiveProperty<int>();
    private ReactiveProperty<bool> isPaused = new ReactiveProperty<bool>(false);

    private void Start()
    {
        remainingTime.Value = startSeconds;

        Observable.Interval(TimeSpan.FromSeconds(1))
            .Where(_ => !isPaused.Value)
            .Subscribe(_ =>
            {
                if (remainingTime.Value > 0)
                {
                    remainingTime.Value--;
                }
            })
            .AddTo(this);

        remainingTime.Subscribe(time => 
        {
            if(time <= 0)
            {
                timerText.text = "Time's up!";
            }
            else
            {
                timerText.text = $"Time Remaining: {time}s";
            }
        })
        .AddTo(this);

        isPaused.Subscribe(paused =>
        {
            if (paused)
            {
                timerText.text += " (Paused)";
            }
        })
        .AddTo(this);
    }

    public void TogglePause()
    {
        isPaused.Value = !isPaused.Value;
    }
}

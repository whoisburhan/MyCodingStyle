using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class StopwatchView : MonoBehaviour, IStopwatchView
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI statusText;

    [SerializeField] private Button startButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button resetButton;


    public event Action OnStartClicked;
    public event Action OnPauseClicked;
    public event Action OnResumeClicked;
    public event Action OnResetClicked;


    private void Awake()
    {
        startButton.onClick.AddListener(() => OnStartClicked?.Invoke());
        pauseButton.onClick.AddListener(() => OnPauseClicked?.Invoke());
        resumeButton.onClick.AddListener(() => OnResumeClicked?.Invoke());
        resetButton.onClick.AddListener(() => OnResetClicked?.Invoke());
    }

    public void SetTimerText(string time) => timeText.text = time;

    public void SetStartInteractable(bool isInteractable) => startButton.interactable = isInteractable;


    public void SetPauseInteractable(bool isInteractable) => pauseButton.interactable = isInteractable;


    public void SetResumeInteractable(bool isInteractable) => resumeButton.interactable = isInteractable;


    public void SetResetInteractable(bool isInteractable) => resetButton.interactable = isInteractable;


    public void SetStatus(string status) => statusText.text = status;


}

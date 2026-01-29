using System;

public interface IStopwatchView
{

    // view -> presenter events
    event Action OnStartClicked;
    event Action OnPauseClicked;
    event Action OnResumeClicked;
    event Action OnResetClicked;

    // presenter -> view methods
    void SetTimerText(string timeText);
    void SetStartInteractable(bool isInteractable);
    void SetPauseInteractable(bool isInteractable);
    void SetResumeInteractable(bool isInteractable);
    void SetResetInteractable(bool isInteractable);
    void SetStatus(string status);

}

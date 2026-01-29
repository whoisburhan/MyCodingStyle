using System;

public sealed class StopwatchPresenter
{
    private readonly IStopwatchModel _model;
    private readonly IStopwatchView _view;
    private readonly ITimeFormatter _timeFormatter;

    public StopwatchPresenter(IStopwatchView view, IStopwatchModel moddel,
        ITimeFormatter timeFormatter)
    {
        _view = view;
        _model = moddel;
        _timeFormatter = timeFormatter;

        _view.OnStartClicked += HandleStart;
        _view.OnPauseClicked += HandlePause;
        _view.OnResumeClicked += HandleResume;
        _view.OnResetClicked += HandleReset;

        RefreshView("Ready");
    }

    public void Dispose()
    {
        _view.OnStartClicked -= HandleStart;
        _view.OnPauseClicked -= HandlePause;
        _view.OnResumeClicked -= HandleResume;
        _view.OnResetClicked -= HandleReset;
    }

    public void Tick(double deltaSeconds)
    {
        _model.Tick(deltaSeconds);
        var formattedTime = _timeFormatter.Format(_model.ElaspsedTime);
        _view.SetTimerText(formattedTime);
    }

    private void HandleStart()
    {
        _model.Start();
        RefreshView(_model.IsPaused ? "Paused" : "Running");
    }

    private void HandlePause()
    {
        _model.Pause();
        RefreshView("Paused");
    }

    private void HandleResume()
    {
        _model.Resume();
        RefreshView("Running");
    }

    private void HandleReset()
    {
        _model.Reset();
        var formattedTime = _timeFormatter.Format(_model.ElaspsedTime);
        _view.SetTimerText(formattedTime);
        RefreshView("Ready");
    }

    private void RefreshView(string staus)
    {
        bool canStart = !_model.IsRunning;
        bool canPause = _model.IsRunning && !_model.IsPaused;
        bool canResume = _model.IsRunning && _model.IsPaused;
        bool canReset = true;

        _view.SetStartInteractable(canStart);
        _view.SetPauseInteractable(canPause);
        _view.SetResumeInteractable(canResume);
        _view.SetResetInteractable(canReset);

        _view.SetTimerText(_timeFormatter.Format(_model.ElaspsedTime));
        _view.SetStatus(staus);
    }
}

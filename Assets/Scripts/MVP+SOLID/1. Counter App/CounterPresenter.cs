using System;
using UnityEngine;

public sealed class CounterPresenter
{
    private readonly ICounterModel _model;
    private readonly ICounterView _view;

    public CounterPresenter(ICounterModel model, ICounterView view)
    {
        _model = model;
        _view = view;

        _view.OnIncrementClicked += HandleIncrementClicked;
        _view.OnDecrementClicked += HandleDecrementClicked;
        _view.OnResetClicked += HandleResetClicked;

        RefreshView();
    }

    public void Dispose() 
    {
        _view.OnIncrementClicked -= HandleIncrementClicked;
        _view.OnDecrementClicked -= HandleDecrementClicked;
        _view.OnResetClicked -= HandleResetClicked;
    }

    private void HandleIncrementClicked()
    {
        if (_model.CanIncrement())
        {
            _model.Increment();
            RefreshView();
        }
    }
    private void HandleDecrementClicked()
    {
        if(_model.CanDecrement())
        {
            _model.Decrement();
            RefreshView();
        }
    }

    private void HandleResetClicked()
    {
        _model.Reset();
        RefreshView();
    }
    private void RefreshView()
    {
        _view.SetCountText(_model.Count.ToString());
        _view.SetIncrementInteractable(_model.CanIncrement());
        _view.SetDecrementInteractable(_model.CanDecrement());
    }
}

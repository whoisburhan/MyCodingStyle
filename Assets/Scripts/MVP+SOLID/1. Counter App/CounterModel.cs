using System;
using UnityEngine;

public sealed class CounterModel : ICounterModel
{
    public int Count  {get; private set; }

    public int Min { get; }

    public int Max { get; }

    int startValue;

    public CounterModel(int min, int max, int startValue = 0)
    {
        Count = startValue;
        Min = min;
        Max = max;
        this.startValue = startValue;
    }

    public bool CanIncrement() => Count < Max;
    public bool CanDecrement() => Count > Min;

    public void Increment()
    {
        if(CanIncrement())
        {
            Count++;
        }
    }
    public void Decrement()
    {
        if(CanDecrement())
        {
            Count--;
        }
    }


    public void Reset()
    {
        Count = startValue;
        Count = Math.Clamp(Count, Min, Max);
    }
}

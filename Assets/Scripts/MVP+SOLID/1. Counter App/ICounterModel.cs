using UnityEngine;

public interface ICounterModel
{
    int Count { get; }
    int Min { get; }
    int Max { get; }

    bool CanIncrement();
    bool CanDecrement();

    void Increment();
    void Decrement();
    void Reset();
}

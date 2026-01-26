public interface IStopwatchModel
{
    bool IsRunning { get; }
    bool IsPaused { get; }
    double ElaspsedTime { get; }

    void Start();
    void Pause();
    void Resume();
    void Reset();

    void Tick(double deltaSeconds);
}

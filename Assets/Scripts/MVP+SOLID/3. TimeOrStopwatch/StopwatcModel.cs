public sealed class StopwatcModel : IStopwatchModel
{
    public bool IsRunning { get; private set; }

    public bool IsPaused { get; private set; }

    public double ElaspsedTime { get; private set; }

    public void Start()
    {
        if(IsRunning)   return;

        IsRunning = true;
        IsPaused = false;
    }

    public void Pause()
    {
        if(!IsRunning || IsPaused)   return;

        IsPaused = true;
    }

    public void Resume()
    {
        if (!IsRunning || !IsPaused) return;

        IsPaused = false;
    }

    public void Reset()
    {
        ElaspsedTime = 0;
        IsRunning= false;
        IsPaused= false;
    }


    public void Tick(double deltaSeconds)
    {
        if (!IsRunning || IsPaused) return;
        if(deltaSeconds < 0)  return;

        ElaspsedTime += deltaSeconds;
        if(ElaspsedTime < 0)    ElaspsedTime = 0;
    }
}

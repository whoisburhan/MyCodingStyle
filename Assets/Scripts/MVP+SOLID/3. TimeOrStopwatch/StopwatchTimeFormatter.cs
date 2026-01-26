public sealed class StopwatchTimeFormatter : ITimeFormatter
{
    // Format mm:ss:ms
    public string Format(double seconds)
    {
        if(seconds < 0)    seconds = 0;

        int totalMilliseconds = (int)(seconds * 1000);
        int minutes = (totalMilliseconds / 60000);
        int secs = (totalMilliseconds % 60000) / 1000;

        // centiseconds (2 digit)
        int centiseconds = (totalMilliseconds % 1000) / 10;

        return $"{minutes:00}:{seconds:00}:{centiseconds:00}";
    }
}

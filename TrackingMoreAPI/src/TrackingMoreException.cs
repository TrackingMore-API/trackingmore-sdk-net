namespace TrackingMoreAPI;

public class TrackingMoreException : Exception
{
    public TrackingMoreException() : base("")
    {
    }

    public TrackingMoreException(string message) : base(message)
    {
    }

    public TrackingMoreException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
namespace TrackingMoreAPI.Model;

public class ApiResponse<T>
{
    public Meta meta { get; set; }
    public T data { get; set; }
}
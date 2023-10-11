using Newtonsoft.Json;

namespace TrackingMoreAPI.Model.Couriers;

public class DetectParams
{
    [JsonProperty("tracking_number")]
    public string trackingNumber { get; set; } = "";

}
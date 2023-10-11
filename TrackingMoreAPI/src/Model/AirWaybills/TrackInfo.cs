using Newtonsoft.Json;

namespace TrackingMoreAPI.Model.AirWaybills;

public class TrackInfo
{
    [JsonProperty("plan_date")]
    public string planDate { get; set; }

    [JsonProperty("actual_date")]
    public string actualDate { get; set; }

    [JsonProperty("event")]
    public string events { get; set; }

    [JsonProperty("station")]
    public string station { get; set; }

    [JsonProperty("flight_number")]
    public string flightNumber { get; set; }

    [JsonProperty("status")]
    public string status { get; set; }

    [JsonProperty("piece")]
    public string piece { get; set; }

    [JsonProperty("weight")]
    public string weight { get; set; }
}
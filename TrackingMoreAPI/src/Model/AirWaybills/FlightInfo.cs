using Newtonsoft.Json;

namespace TrackingMoreAPI.Model.AirWaybills;

public class FlightInfo
{
    [JsonProperty("plan_arrival_time")]
    public string planArrivalTime { get; set; }

    [JsonProperty("arrival_time")]
    public string arrivalTime { get; set; }

    [JsonProperty("arrival_station")]
    public string arrivalStation { get; set; }

    [JsonProperty("plan_depart_time")]
    public string planDepartTime { get; set; }

    [JsonProperty("depart_time")]
    public string departTime { get; set; }

    [JsonProperty("depart_station")]
    public string departStation { get; set; }
}
using Newtonsoft.Json;

namespace TrackingMoreAPI.Model.AirWaybills;

public class AirWaybills
{
    [JsonProperty("awb_number")]
    public string awbNumber { get; set; }

    [JsonProperty("awb_status")]
    public string awbStatus { get; set; }

    [JsonProperty("awb_substatus")]
    public string awbSubstatus { get; set; }

    [JsonProperty("status_number")]
    public string statusNumber { get; set; }

    [JsonProperty("weight")]
    public string weight { get; set; }

    [JsonProperty("piece")]
    public string piece { get; set; }

    [JsonProperty("origin")]
    public string origin { get; set; }

    [JsonProperty("destination")]
    public string destination { get; set; }

    [JsonProperty("flight_way_station")]
    public string[] flightWayStation { get; set; }

    [JsonProperty("last_event")]
    public string lastEvent { get; set; }

    [JsonProperty("flight_info_new")]
    public FlightInfoNew[] flightInfoNew { get; set; }

    [JsonProperty("flight_info")]
    public Dictionary<string, FlightInfo> flightInfo { get; set; }

    [JsonProperty("track_info")]
    public TrackInfo[] trackInfo { get; set; }

    [JsonProperty("airline_info")]
    public AirlineInfo airlineInfo { get; set; }

}
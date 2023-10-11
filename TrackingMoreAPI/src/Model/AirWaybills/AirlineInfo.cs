using Newtonsoft.Json;

namespace TrackingMoreAPI.Model.AirWaybills;

public class AirlineInfo
{
    [JsonProperty("name")]
    public string name { get; set; }

    [JsonProperty("url")]
    public string url { get; set; }

    [JsonProperty("track_url")]
    public string trackUrl { get; set; }

    [JsonProperty("trackpage_url2")]
    public string trackpageUrl2 { get; set; }

}
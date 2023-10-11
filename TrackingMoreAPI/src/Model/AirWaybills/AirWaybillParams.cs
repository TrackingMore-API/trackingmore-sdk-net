using Newtonsoft.Json;

namespace TrackingMoreAPI.Model.AirWaybills;

public class AirWaybillParams
{
    [JsonProperty("awb_number")]
    public string awbNumber { get; set; }

}
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using TrackingMoreAPI.Model;
using TrackingMoreAPI.Model.AirWaybills;

namespace TrackingMoreAPI;

public class AirWaybill : Base
{

    public ApiResponse<AirWaybills> CreateAnAirWayBill(AirWaybillParams airWaybillParams){
        if (string.IsNullOrEmpty(airWaybillParams.awbNumber))
        {
            throw new TrackingMoreException(Enums.ErrMissingAwbNumber);
        }
        if (!Regex.IsMatch(airWaybillParams.awbNumber, @"^\d{3}[ -]?(\d{8})$"))
        {    
            throw new TrackingMoreException(Enums.ErrInvalidAirWaybillFormat);
        }
        HttpMethod method = HttpMethod.Post;
        var responseData = request.MakeRequest("awb", method, airWaybillParams);

        ApiResponse<AirWaybills> response = JsonConvert.DeserializeObject<ApiResponse<AirWaybills>>(responseData);
        return response;
        
    }

}
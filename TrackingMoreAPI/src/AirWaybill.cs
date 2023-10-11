using Newtonsoft.Json;
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
        if (airWaybillParams.awbNumber.Length != 12)
        {
            throw new TrackingMoreException(Enums.ErrInvalidAirWaybillFormat);
        }
        HttpMethod method = HttpMethod.Post;
        var responseData = request.MakeRequest("awb", method, airWaybillParams);

        ApiResponse<AirWaybills> response = JsonConvert.DeserializeObject<ApiResponse<AirWaybills>>(responseData);
        return response;
        
    }

}
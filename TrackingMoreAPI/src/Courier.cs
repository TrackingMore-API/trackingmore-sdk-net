using Newtonsoft.Json;
using TrackingMoreAPI.Model;
using TrackingMoreAPI.Model.Couriers;

namespace TrackingMoreAPI;

public class Courier : Base
{

    private string _apiModule = "couriers";

    public ApiResponse<List<Couriers>> GetAllCouriers(){
        
        HttpMethod method = HttpMethod.Get;
        var responseData = request.MakeRequest(_apiModule + "/all", method);

        ApiResponse<List<Couriers>> response = JsonConvert.DeserializeObject<ApiResponse<List<Couriers>>>(responseData);
        return response;
      
    }

    public ApiResponse<List<Couriers>> detect(DetectParams detectParams){
        if (string.IsNullOrEmpty(detectParams.trackingNumber))
        {
            throw new TrackingMoreException(Enums.ErrMissingTrackingNumber);
        }
        HttpMethod method = HttpMethod.Post;
        var responseData = request.MakeRequest(_apiModule + "/detect", method, detectParams);

        ApiResponse<List<Couriers>> response = JsonConvert.DeserializeObject<ApiResponse<List<Couriers>>>(responseData);
        return response;
        
    }

}
using Newtonsoft.Json;
using TrackingMoreAPI.Model;
using TrackingMoreAPI.Model.Trackings;



namespace TrackingMoreAPI;

public class Tracking : Base
{

    private string _apiModule = "trackings";

    public ApiResponse<Trackings> CreateTracking(CreateTrackingParams createTrackingParams){
        if (string.IsNullOrEmpty(createTrackingParams.trackingNumber))
        {
            throw new TrackingMoreException(Enums.ErrMissingTrackingNumber);
        }

        if (string.IsNullOrEmpty(createTrackingParams.courierCode))
        {
            throw new TrackingMoreException(Enums.ErrMissingCourierCode);
        }

        HttpMethod method = HttpMethod.Post;
        var responseData = request.MakeRequest(_apiModule + "/create", method, createTrackingParams);

        ApiResponse<Trackings> response = JsonConvert.DeserializeObject<ApiResponse<Trackings>>(responseData);
        return response;
        
    }

    public ApiResponse<List<Trackings>> GetTrackingResults(GetTrackingResultsParams getTrackingResultsParams){

        HttpMethod method = HttpMethod.Get;
        var responseData = request.MakeRequest(_apiModule + "/get", method, getTrackingResultsParams);

        ApiResponse<List<Trackings>> response = JsonConvert.DeserializeObject<ApiResponse<List<Trackings>>>(responseData);
        return response;
        
    }

    public ApiResponse<BatchResults> BatchCreateTrackings(List<CreateTrackingParams> trackingParamsList){
        if (trackingParamsList.Count > 40)
        {
            throw new TrackingMoreException(Enums.ErrMaxTrackingNumbersExceeded);
        }

        foreach (var item in trackingParamsList)
        {
            if (string.IsNullOrEmpty(item.trackingNumber)){
                throw new TrackingMoreException(Enums.ErrMissingTrackingNumber);
            }

            if (string.IsNullOrEmpty(item.courierCode)){
                throw new TrackingMoreException(Enums.ErrMissingCourierCode);
            }
        }

        HttpMethod method = HttpMethod.Post;
        var responseData = request.MakeRequest(_apiModule + "/batch", method, trackingParamsList);

        ApiResponse<BatchResults> response = JsonConvert.DeserializeObject<ApiResponse<BatchResults>>(responseData);
        return response;
        
    }

    public ApiResponse<UpdateTracking> UpdateTrackingByID(string idString,UpdateTrackingParams updateTrackingParams){
        if (string.IsNullOrEmpty(idString))
        {
            throw new TrackingMoreException(Enums.ErrEmptyId);
        }

        HttpMethod method = HttpMethod.Put;
        var responseData = request.MakeRequest(_apiModule + "/update/" + idString, method, updateTrackingParams);

        ApiResponse<UpdateTracking> response = JsonConvert.DeserializeObject<ApiResponse<UpdateTracking>>(responseData);
        return response;
        
    }

    public ApiResponse<Trackings> DeleteTrackingByID(string idString){
        if (string.IsNullOrEmpty(idString))
        {
            throw new TrackingMoreException(Enums.ErrEmptyId);
        }

        HttpMethod method = HttpMethod.Delete;
        var responseData = request.MakeRequest(_apiModule + "/delete/" + idString, method, null);

        ApiResponse<Trackings> response = JsonConvert.DeserializeObject<ApiResponse<Trackings>>(responseData);
        return response;
        
    }

    public ApiResponse<Trackings> RetrackTrackingByID(string idString){
        if (string.IsNullOrEmpty(idString))
        {
            throw new TrackingMoreException(Enums.ErrEmptyId);
        }

        HttpMethod method = HttpMethod.Post;
        var responseData = request.MakeRequest(_apiModule + "/retrack/" + idString, method, null);

        ApiResponse<Trackings> response = JsonConvert.DeserializeObject<ApiResponse<Trackings>>(responseData);
        return response;
        
    }

}
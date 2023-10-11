using TrackingMoreAPI.Model.Couriers;
using TrackingMoreAPI.Model.AirWaybills;
using TrackingMoreAPI.Model.Trackings;
using TrackingMoreAPI.Model;

namespace TrackingMoreAPI;

public class Test
{

      static void Main(string[] args)
      {
        try
        {
            string apiKey = "you api key";
            TrackingMore trackingMore = new TrackingMore(apiKey);

            var apiResponse = trackingMore.Courier.GetAllCouriers();
            Console.WriteLine(apiResponse.meta.code);
            foreach (var item in apiResponse.data)
            {
                Console.WriteLine("courierName: " + item.courierName);
                Console.WriteLine("courierCode: " + item.courierCode);
                Console.WriteLine();
            }
            
            // DetectParams detectParams = new DetectParams();
            // detectParams.trackingNumber = "9261290306531704519171";
            // var apiResponse = trackingMore.Courier.detect(detectParams);
            // Console.WriteLine(apiResponse.meta.code);
            // foreach (var item in apiResponse.data)
            // {
            //     Console.WriteLine("courierName: " + item.courierName);
            //     Console.WriteLine("courierCode: " + item.courierCode);
                
            //     Console.WriteLine();
            // }

            // AirWaybillParams airWaybillParams = new AirWaybillParams();
            // airWaybillParams.awbNumber = "235-69030430";
            // var apiResponse = trackingMore.AirWaybill.CreateAnAirWayBill(airWaybillParams);
            // Console.WriteLine(apiResponse.meta.code);
            // Console.WriteLine(apiResponse.data.awbNumber);
            // Console.WriteLine(apiResponse.data.flightInfoNew[0].flightNumber);
            // Console.WriteLine(apiResponse.data.flightInfo["TK0721"].departStation);

            // CreateTrackingParams createTrackingParams = new CreateTrackingParams();
            // createTrackingParams.trackingNumber = "9261290306531704519171";
            // createTrackingParams.courierCode = "usps";
            // var apiResponse = trackingMore.Tracking.CreateTracking(createTrackingParams);
            // Console.WriteLine(apiResponse.meta.code);
            // Console.WriteLine(apiResponse.data.trackingNumber);
            // Console.WriteLine(apiResponse.data.courierCode);

            // GetTrackingResultsParams getTrackingResultsParams = new GetTrackingResultsParams();
            // getTrackingResultsParams.trackingNumbers = "9261290306531704519171,92612903029511573030094547";
            // getTrackingResultsParams.courierCode = "usps";
            // getTrackingResultsParams.createdDateMin = "2023-10-09T06:00:00+00:00";
            // getTrackingResultsParams.createdDateMax = "2023-10-10T13:45:00+00:00";
            // var apiResponse = trackingMore.Tracking.GetTrackingResults(getTrackingResultsParams);
            // Console.WriteLine(apiResponse.meta.code);
            // foreach (var item in apiResponse.data)
            // {
            //     Console.WriteLine("trackingNumber: " + item.trackingNumber);
            //     Console.WriteLine("courierCode: " + item.courierCode);
                
            //     Console.WriteLine();
            // }

            // List<CreateTrackingParams> trackingParamsList = new List<CreateTrackingParams>();

            // CreateTrackingParams trackingParams1 = new CreateTrackingParams
            // {
            //     trackingNumber = "9261290306531704519172",
            //     courierCode = "usps"
            // };

            // trackingParamsList.Add(trackingParams1);

            // CreateTrackingParams trackingParams2 = new CreateTrackingParams
            // {
            //     trackingNumber = "9261290306531704519174",
            //     courierCode = "usps"
            // };

            // trackingParamsList.Add(trackingParams2);
            // var apiResponse = trackingMore.Tracking.BatchCreateTrackings(trackingParamsList);
            // Console.WriteLine(apiResponse.meta.code);
            // foreach (var item in apiResponse.data.success)
            // {
            //     Console.WriteLine("trackingNumber: " + item.trackingNumber);
            //     Console.WriteLine("courierCode: " + item.courierCode);
                
            //     Console.WriteLine();
            // }

            // foreach (var item in apiResponse.data.error)
            // {
            //     Console.WriteLine("trackingNumber: " + item.trackingNumber);
            //     Console.WriteLine("courierCode: " + item.courierCode);
                
            //     Console.WriteLine();
            // }

            // UpdateTrackingParams updateTrackingParams = new UpdateTrackingParams();
            // updateTrackingParams.customerName = "New name";
            // updateTrackingParams.note = "New tests order note";
            // string idString = "9a557acc90dd57df78933fcc09ab9657";
            // var apiResponse = trackingMore.Tracking.UpdateTrackingByID(idString, updateTrackingParams);
            // Console.WriteLine(apiResponse.meta.code);
            // if(apiResponse.data != null){
            //     Console.WriteLine(apiResponse.data.trackingNumber);
            //     Console.WriteLine(apiResponse.data.courierCode);
            //     Console.WriteLine(apiResponse.data.customerName);
            //     Console.WriteLine(apiResponse.data.note);
            // }

            // string idString = "9a5575a8b14833ff3a34d357709707b7";
            // var apiResponse = trackingMore.Tracking.DeleteTrackingByID(idString);
            // Console.WriteLine(apiResponse.meta.code);
            // if(apiResponse.data != null){
            //     Console.WriteLine(apiResponse.data.trackingNumber);
            //     Console.WriteLine(apiResponse.data.courierCode);
            // }

           
            // string idString = "9a5575a8b14833ff3a34d357709707b7";
            // var apiResponse = trackingMore.Tracking.RetrackTrackingByID(idString);
            // Console.WriteLine(apiResponse.meta.code);
            // if(apiResponse.data != null){
            //     Console.WriteLine(apiResponse.data.trackingNumber);
            //     Console.WriteLine(apiResponse.data.courierCode);
            // }
           

        }
        catch (TrackingMoreException ex)
        {
            Console.WriteLine("Catch custom exceptions：" + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Catch other exceptions:" + ex.Message);
        }

      }

}
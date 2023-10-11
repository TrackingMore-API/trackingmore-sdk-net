trackingmore-sdk-net
=================

The .Net SDK of Trackingmore API

Contact: <manage@trackingmore.org>

## Official document

[Document](https://www.trackingmore.com/docs/trackingmore/d5ac362fc3cda-api-quick-start)

## Index
1. [Installation](https://github.com/TrackingMores/trackingmore-sdk-net#installation)
2. [Testing](https://github.com/TrackingMores/trackingmore-sdk-net#testing)
3. [Error Handling](https://github.com/TrackingMores/trackingmore-sdk-net#error-handling)
4. SDK
    1. [Couriers](https://github.com/TrackingMores/trackingmore-sdk-net#couriers)
    2. [Trackings](https://github.com/TrackingMores/trackingmore-sdk-net#trackings)
    3. [Air Waybill](https://github.com/TrackingMores/trackingmore-sdk-net#air-waybill)


## Installation

Downloading the NuGet package using the dotnet CLI

```
$ dotnet add package trackingmore
```

Downloading NuGet Packages with the NuGet Command Line Tool

```
$ nuget install trackingmore
```

The difference with dotnet cli is that you need to manually modify the .csproj file and add the following code

```text
<ItemGroup>
    <PackageReference Include="TrackingMore" Version="X.Y.Z" />
</ItemGroup>
```

## Quick Start

```c#
using TrackingMoreAPI;

namespace Testing;

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
```

## Testing

In the root directory of the test project, run the following command to execute the test
```
dotnet test
```

## Error handling

**Throw** by the new SDK client

```c#
try
{
    string apiKey = "";
    TrackingMore trackingMore = new TrackingMore(apiKey);
}
catch (TrackingMoreException ex)
{
    Console.WriteLine("Catch custom exceptions：" + ex.Message);
}

# API Key is missing
```

**Throw** by the parameter validation in function

```c#
try
{
    string apiKey = "you api key";
    TrackingMore trackingMore = new TrackingMore(apiKey);

    DetectParams detectParams = new DetectParams();
    detectParams.trackingNumber = "";
    var apiResponse = trackingMore.Courier.detect(detectParams);
}
catch (TrackingMoreException ex)
{
    Console.WriteLine("Catch custom exceptions：" + ex.Message);
}

# Tracking number cannot be empty
```
## Examples

## Couriers
##### Return a list of all supported couriers.
https://api.trackingmore.com/v4/couriers/all
```c#
var apiResponse = trackingMore.Courier.GetAllCouriers();
Console.WriteLine(apiResponse.meta.code);
foreach (var item in apiResponse.data)
{
    Console.WriteLine("courierName: " + item.courierName);
    Console.WriteLine("courierCode: " + item.courierCode);
    Console.WriteLine();
}
```

##### Return a list of matched couriers based on submitted tracking number.
https://api.trackingmore.com/v4/couriers/detect
```c#
DetectParams detectParams = new DetectParams();
detectParams.trackingNumber = "9261290306531704519171";
var apiResponse = trackingMore.Courier.detect(detectParams);
Console.WriteLine(apiResponse.meta.code);
foreach (var item in apiResponse.data)
{
    Console.WriteLine("courierName: " + item.courierName);
    Console.WriteLine("courierCode: " + item.courierCode);
    
    Console.WriteLine();
}
```

## Trackings
##### Create a tracking.
https://api.trackingmore.com/v4/trackings/create
```c#
CreateTrackingParams createTrackingParams = new CreateTrackingParams();
createTrackingParams.trackingNumber = "9261290306531704519171";
createTrackingParams.courierCode = "usps";
var apiResponse = trackingMore.Tracking.CreateTracking(createTrackingParams);
Console.WriteLine(apiResponse.meta.code);
Console.WriteLine(apiResponse.data.trackingNumber);
Console.WriteLine(apiResponse.data.courierCode);

```

##### Get tracking results of multiple trackings.
https://api.trackingmore.com/v4/trackings/get
```c#
GetTrackingResultsParams getTrackingResultsParams = new GetTrackingResultsParams();
getTrackingResultsParams.trackingNumbers = "9261290306531704519171,92612903029511573030094547";
getTrackingResultsParams.courierCode = "usps";
getTrackingResultsParams.createdDateMin = "2023-10-09T06:00:00+00:00";
getTrackingResultsParams.createdDateMax = "2023-10-10T13:45:00+00:00";
var apiResponse = trackingMore.Tracking.GetTrackingResults(getTrackingResultsParams);
Console.WriteLine(apiResponse.meta.code);
foreach (var item in apiResponse.data)
{
    Console.WriteLine("trackingNumber: " + item.trackingNumber);
    Console.WriteLine("courierCode: " + item.courierCode);
    
    Console.WriteLine();
}
```

##### Create multiple trackings (Max. 40 tracking numbers create in one call).
https://api.trackingmore.com/v4/trackings/batch
```c#
List<CreateTrackingParams> trackingParamsList = new List<CreateTrackingParams>();

CreateTrackingParams trackingParams1 = new CreateTrackingParams
{
    trackingNumber = "9261290306531704519172",
    courierCode = "usps"
};

trackingParamsList.Add(trackingParams1);

CreateTrackingParams trackingParams2 = new CreateTrackingParams
{
    trackingNumber = "9261290306531704519174",
    courierCode = "usps"
};

trackingParamsList.Add(trackingParams2);
var apiResponse = trackingMore.Tracking.BatchCreateTrackings(trackingParamsList);
Console.WriteLine(apiResponse.meta.code);
foreach (var item in apiResponse.data.success)
{
    Console.WriteLine("trackingNumber: " + item.trackingNumber);
    Console.WriteLine("courierCode: " + item.courierCode);
    
    Console.WriteLine();
}

foreach (var item in apiResponse.data.error)
{
    Console.WriteLine("trackingNumber: " + item.trackingNumber);
    Console.WriteLine("courierCode: " + item.courierCode);
    
    Console.WriteLine();
}
```

##### Update a tracking by ID.
https://api.trackingmore.com/v4/trackings/update/{id}
```c#
UpdateTrackingParams updateTrackingParams = new UpdateTrackingParams();
updateTrackingParams.customerName = "New name";
updateTrackingParams.note = "New tests order note";
string idString = "9a557acc90dd57df78933fcc09ab9657";
var apiResponse = trackingMore.Tracking.UpdateTrackingByID(idString, updateTrackingParams);
Console.WriteLine(apiResponse.meta.code);
if(apiResponse.data != null){
    Console.WriteLine(apiResponse.data.trackingNumber);
    Console.WriteLine(apiResponse.data.courierCode);
    Console.WriteLine(apiResponse.data.customerName);
    Console.WriteLine(apiResponse.data.note);
}
```

##### Delete a tracking by ID.
https://api.trackingmore.com/v4/trackings/delete/{id}
```c#
string idString = "9a5575a8b14833ff3a34d357709707b7";
var apiResponse = trackingMore.Tracking.RetrackTrackingByID(idString);
Console.WriteLine(apiResponse.meta.code);
if(apiResponse.data != null){
    Console.WriteLine(apiResponse.data.trackingNumber);
    Console.WriteLine(apiResponse.data.courierCode);
}
```

##### Retrack expired tracking by ID.
https://api.trackingmore.com/v4/trackings/retrack/{id}
```c#
string idString = "9a5575a8b14833ff3a34d357709707b7";
var apiResponse = trackingMore.Tracking.RetrackTrackingByID(idString);
Console.WriteLine(apiResponse.meta.code);
if(apiResponse.data != null){
    Console.WriteLine(apiResponse.data.trackingNumber);
    Console.WriteLine(apiResponse.data.courierCode);
}
```
## Air Waybill
##### Create an air waybill.
https://api.trackingmore.com/v4/awb
```c#
AirWaybillParams airWaybillParams = new AirWaybillParams();
airWaybillParams.awbNumber = "235-69030430";
var apiResponse = trackingMore.AirWaybill.CreateAnAirWayBill(airWaybillParams);
Console.WriteLine(apiResponse.meta.code);
Console.WriteLine(apiResponse.data.awbNumber);
Console.WriteLine(apiResponse.data.flightInfoNew[0].flightNumber);
Console.WriteLine(apiResponse.data.flightInfo["TK0721"].departStation);

```

## Response Code

Trackingmore uses conventional HTTP response codes to indicate success or failure of an API request. In general, codes in the 2xx range indicate success, codes in the 4xx range indicate an error that resulted from the provided information (e.g. a required parameter was missing, a charge failed, etc.), and codes in the 5xx range indicate an TrackingMore's server error.


Http CODE|META CODE|TYPE | MESSAGE
----|-----|--------------|-------------------------------
200    |200     | <code>Success</code>        |    Request response is successful
400    |400     | <code>BadRequest</code>     |    Request type error. Please check the API documentation for the request type of this API.
400    |4101    | <code>BadRequest</code>     |    Tracking No. already exists.
400    |4102    | <code>BadRequest</code>     |    Tracking No. no exists. Please use 「Create a tracking」 API first to create shipment.
400    |4103    | <code>BadRequest</code>     |    You have exceeded the shipment quantity of API call. The maximum quantity is 40 shipments per call.
400    |4110    | <code>BadRequest</code>     |    The value of tracking_number is invalid.
400    |4111    | <code>BadRequest</code>     |    Tracking_number is required.
400    |4112    | <code>BadRequest</code>     |    Invalid Tracking ID.
400    |4113    | <code>BadRequest</code>     |    Retrack is not allowed. You can only retrack an expired tracking.
400    |4120    | <code>BadRequest</code>     |    The value of courier_code is invalid.
400    |4121    | <code>BadRequest</code>     |    Cannot detect courier.
400    |4122    | <code>BadRequest</code>     |    Missing or invalid value of the special required fields for this courier.
400    |4130    | <code>BadRequest</code>     |    The format of Field name is invalid.
400    |4160    | <code>BadRequest</code>     |    The awb_number is required or invaild format.
400    |4161    | <code>BadRequest</code>     |    The awb airline does not support yet.
400    |4190    | <code>BadRequest</code>     |    You are reaching the maximum quota limitation, please upgrade your current plan.
401    |401     | <code>Unauthorized</code>   |    Authentication failed or has no permission. Please check and ensure your API Key is correct.
403    |403     | <code>Forbidden</code>      |    Access prohibited. The request has been refused or access is not allowed.
404    |404     | <code>NotFound</code>       |    Page does not exist. Please check and ensure your link is correct.
429    |429     | <code>TooManyRequests</code>|    Exceeded API request limits, please try again later. Please check the API documentation for the limit of this API.
500    |511     | <code>ServerError</code>    |    Server error. Please contact us: service@trackingmore.org.
500    |512     | <code>ServerError</code>    |    Server error. Please contact us: service@trackingmore.org.
500    |513     | <code>ServerError</code>    |    Server error. Please contact us: service@trackingmore.org.
using TrackingMoreAPI;
using TrackingMoreAPI.Model.Couriers;

namespace Test;

public class CourierTest
{

    public TrackingMore trackingMore;

    public CourierTest(){
        string apiKey = "you api key";
        this.trackingMore = new TrackingMore(apiKey);
    }

    [Fact]
    public void TestGetAllCouriers()
    {

        var response = trackingMore.Courier.GetAllCouriers();

        Assert.NotNull(response);
    }

    [Fact]
    public void TestDetectMethodWithValidTrackingNumber()
    {
        var detectParams = new DetectParams
        {
            trackingNumber = "9261290306531704519171" 
        };

        var response = trackingMore.Courier.detect(detectParams);
        
        Assert.NotNull(response);
        Assert.NotNull(response.data); 
    }

    [Fact]
    public void TestDetectMethodWithMissingTrackingNumber()
    {
        var detectParams = new DetectParams
        {
            trackingNumber = null
        };

        var exception = Assert.Throws<TrackingMoreException>(() => trackingMore.Courier.detect(detectParams));

        Assert.Equal(Enums.ErrMissingTrackingNumber, exception.Message); 
    }

}
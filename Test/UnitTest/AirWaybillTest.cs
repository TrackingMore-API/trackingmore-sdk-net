using TrackingMoreAPI;
using TrackingMoreAPI.Model.AirWaybills;

namespace Test;

public class AirWaybillTest
{

    public TrackingMore trackingMore;

    public AirWaybillTest(){
        string apiKey = "your api key";
        this.trackingMore = new TrackingMore(apiKey);
    }

    [Fact]
    public void TestCreateAnAirWayBillWithMissingAwbNumber()
    {
        var airWaybillParams = new AirWaybillParams
        {
            awbNumber = null 
        };


        var exception = Assert.Throws<TrackingMoreException>(() => trackingMore.AirWaybill.CreateAnAirWayBill(airWaybillParams));

        Assert.Equal(Enums.ErrMissingAwbNumber, exception.Message);
    }

    [Fact]
    public void TestCreateAnAirWayBillWithInvalidAwbNumberFormat()
    {
        var airWaybillParams = new AirWaybillParams
        {
            awbNumber = "123456" 
        };

        var exception = Assert.Throws<TrackingMoreException>(() => trackingMore.AirWaybill.CreateAnAirWayBill(airWaybillParams));

        Assert.Equal(Enums.ErrInvalidAirWaybillFormat, exception.Message);
    }

    [Fact]
    public void TestCreateAnAirWayBillWithValidAwbNumber()
    {
        var airWaybillParams = new AirWaybillParams
        {
            awbNumber = "235-69030430"
        };

        var response = trackingMore.AirWaybill.CreateAnAirWayBill(airWaybillParams);

        Assert.NotNull(response);

    }

}
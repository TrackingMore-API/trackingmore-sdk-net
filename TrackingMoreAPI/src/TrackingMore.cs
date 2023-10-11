namespace TrackingMoreAPI;

public class TrackingMore
{

      public Courier Courier { get; }

      public AirWaybill AirWaybill { get; }

      public Tracking Tracking { get; }

      public static string apiKey;

      public TrackingMore(string key)
      {
        if (string.IsNullOrEmpty(key))
        {
            throw new TrackingMoreException(Enums.ErrEmptyAPIKey);
        }
        TrackingMore.apiKey = key;
        this.Courier = new Courier();
        this.AirWaybill = new AirWaybill();
        this.Tracking = new Tracking();
      }
      
}

namespace com.hotelbeds.distribution.hotel_api_sdk.types
{
    public class HotelApiVersion
    {
        public enum versions { V0_2, V1 };

        public versions version { get; set; }

        public HotelApiVersion(versions version)
        {
            this.version = version;
        }
    }
}

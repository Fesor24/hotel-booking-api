namespace HB.Infrastructure.Configurations;
public class HotelBedConfiguration
{
    public const string CONFIGURATION_NAME = "HotelBed";
    public string ApiKey { get; set; }
    public string Secret { get; set; }
    public string Url { get; set; }
}

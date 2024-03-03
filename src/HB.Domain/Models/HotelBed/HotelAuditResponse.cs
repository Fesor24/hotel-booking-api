namespace HB.Domain.Models.HotelBed;
public class HotelAuditResponse
{
    public string ProcessTime { get; set; }
    public string Timestamp { get; set; }
    public string RequestHost { get; set; }
    public string ServerId { get; set; }
    public string Environment { get; set; }
    public string Release { get; set; }
    public string Token { get; set; }
    public string Internal { get; set; }
}

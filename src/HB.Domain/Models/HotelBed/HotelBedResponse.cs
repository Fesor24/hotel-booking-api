using System.Text.Json.Serialization;

namespace HB.Domain.Models.HotelBed;
public class HotelBedStatusResponse
{
    [JsonPropertyName("auditData")]
    public Audit AuditData { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }
    public class Audit
    {
        [JsonPropertyName("timestamp")]
        public string TimeStamp { get; set; }
    }
}

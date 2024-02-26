using System.Text.Json.Serialization;

namespace HB.Domain.Models.HotelBed;
public class HotelSearch
{
    [JsonPropertyName("stay")]
    public HotelStay Stay { get; set; }
    [JsonPropertyName("occupancies")]
    public List<Occupancy> Occupancies { get; } = new();
    [JsonPropertyName("dailyRate")]
    public bool DailyRate => true;

    public class HotelStay
    {
        [JsonPropertyName("checkIn")]
        public string CheckIn { get; set; }
        [JsonPropertyName("checkOut")]
        public string CheckOut { get; set; }
    }

    public class Occupancy
    {
        [JsonPropertyName("rooms")]
        public int Rooms { get; set; } = 1;
        [JsonPropertyName("adults")]
        public int Adults { get; set; } = 1;
        [JsonPropertyName("children")]
        public int Children { get; set; } = 0;
    }
}

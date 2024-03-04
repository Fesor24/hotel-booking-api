namespace HB.Domain.Models.HotelBed;
public class HotelRate
{
    public List<Room> Rooms { get; set; } = new();

    public class Room
    {
        public string RateKey { get; set; }
    }
}

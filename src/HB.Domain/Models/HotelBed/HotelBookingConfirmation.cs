namespace HB.Domain.Models.HotelBed;
public class HotelBookingConfirmation
{
    public BookingHolder Holder { get; set; } = new();
    public string ClientReference { get; set; }
    public List<Room> Rooms { get; set; } = new();
    public string Remark { get; set; }
    public string Tolerance { get; set; } = "80.00";

    public class BookingHolder
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Room
    {
        public string RateKey { get; set; }

    }
}

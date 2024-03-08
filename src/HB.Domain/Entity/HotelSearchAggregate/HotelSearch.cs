namespace HB.Domain.Entity.HotelSearchAggregate;
public class HotelSearch : BaseEntity
{
    public string Location { get; set; }
    public SearchDuration Duration { get; set; }
    public HotelOccupants Occupants { get; set; }
    public class SearchDuration
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }

    public class HotelOccupants
    {
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Rooms { get; set; }
    }
}

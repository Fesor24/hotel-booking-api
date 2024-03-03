namespace HB.Domain.Models.HotelBed;
public class HotelLocationResponse
{
    public int From { get; set; }
    public int To { get; set; }
    public int Total { get; set; }

    public HotelAuditResponse AuditData { get; set; } = new();
    public List<Country> Countries { get; set; } = new();

    public class Country
    {
        public string Code { get; set; }
        public string IsoCode { get; set; }
        public CountryDescription Description { get; set; } = new();
        public List<State> States { get; set; } = new();

        public class CountryDescription
        {
            public string Content { get; set; }
        }

        public class State
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }
    }
}

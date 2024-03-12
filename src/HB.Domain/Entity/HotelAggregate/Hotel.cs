namespace HB.Domain.Entity.HotelAggregate;
public class Hotel : BaseEntity
{
    public int Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CountryCode { get; set; }
    public string StateCode { get; set; }
    public string DestinationCode { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Email { get; set; }
    public string License { get; set; }
    public List<PhoneContact> Contact { get; set; }
    public List<string> Images { get; set; }
    public int Ranking { get; set; }

    public class PhoneContact
    {
        public string PhoneNumber { get; set; }
        public string PhoneType { get; set; }
    }
   
}

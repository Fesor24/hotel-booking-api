namespace HB.Domain.Models.HotelBed;
public class HotelBookingConfirmationResponse
{
    public HotelAuditResponse AuditData { get; set; }
    public HotelBooking Booking { get; set; } = new();

    public class HotelBooking
    {
        public string Reference { get; set; }
        public string ClientReference { get; set; }
        public string CreationDate { get; set; }
        public string Status { get; set; }
        public ModificationPolicy ModificationPolicies { get; set; } = new();
        public string CreationUser { get; set; }
        public BookingHolder Holder { get; set; } = new();
        public BookedHotel Hotel { get; set; } = new();
        public string Remark { get; set; }
        public InvoiceCo InvoiceCompany { get; set; } = new();
        public decimal TotalNet { get; set; }
        public decimal PendingAmount { get; set; }
        public string Currency { get; set; }

        public class InvoiceCo
        {
            public string Code { get; set; }
            public string Company { get; set; }
            public string RegistrationNumber { get; set; }
        }
        
        public class BookingHolder
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }

        public class ModificationPolicy
        {
            public bool Cancellation { get; set; }
            public bool Modification { get; set; }
        }

        public class BookedHotel
        {
            public string CheckOut { get; set; }
            public string CheckIn { get; set; }
            public int Code { get; set; }
            public string Name { get; set; }
            public string CategoryCode { get; set; }
            public string CategoryName { get; set; }
            public string DestinationCode { get; set; }
            public string DestinationName { get; set; }
            public int ZoneCode { get; set; }
            public string ZoneName { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public List<Room> Rooms { get; set; } = new();
        }

        public class Room
        {
            public string Status { get; set; }
            public int Id { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public List<Pax> Paxes { get; set; } = new();
            public List<Rate> Rates { get; set; } = new();

            public class Pax
            {
                public int RoomId { get; set; }
                public string Type { get; set; }
            }

            public class Rate
            {
                public string RateClass { get; set; }
                public string Net { get; set; }
                public string RateComments { get; set; }
                public string PaymentType { get; set; }
                public bool Packaging { get; set; }
                public string BoardCode { get; set; }
                public string BoardName { get; set;}

                public List<CancellationPolicy> CancellationPolicies { get; set; } = new();
                public BreakDown RateBreakDown { get; set; } = new();
                public int Rooms { get; set; }
                public int Adults { get; set; }
                public int Children { get; set; }

                public class CancellationPolicy
                {
                    public string Amount { get; set; }
                    public DateTime From { get; set; }
                }

                public class BreakDown
                {
                    public List<RateSupplement> RateSupplements { get; set; } = new();

                    public class RateSupplement
                    {
                        public string Code { get; set; }
                        public string Name { get; set; }
                        public string From { get; set; }
                        public string To { get; set; }
                        public string Amount { get; set; }
                        public int Nights { get; set; }
                        public int PaxNumber { get; set; }
                    }
                }

            }
        }
    }
}

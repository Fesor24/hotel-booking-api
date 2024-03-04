namespace HB.Domain.Models.HotelBed;
public class HotelRateResponse
{
    public HotelAuditResponse AuditData { get; set; } = new();
    public HotelRate Hotel { get; set; } = new();
    public class HotelRate
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
        public List<Room> Rooms { get; set; }
        public string TotalNet { get; set; }
        public string Currency { get; set; }
        public bool PaymentDataRequired { get; set; }

        public ModificationPolicy ModificationPolicies { get; set; } = new();

        public class ModificationPolicy
        {
            public bool Cancellation { get; set; }
            public bool Modification { get; set; }
        }

        public class Room
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public List<Rate> Rates { get; set; }

            public class Rate
            {
                public string RateKey { get; set; }
                public string RateClass { get; set; }
                public string Net { get; set; }
                public int Allotment { get; set; }
                public string RateComments { get; set; }
                public string PaymentType { get; set; }
                public bool Packaging { get; set; }
                public string BoardCode { get; set; }
                public string BoardName { get; set;}
                public List<CancellationPolicy> CancellationPolicies { get; set; } = new();
                public Breakdown RateBreakDown { get; set; } = new();
                public int Rooms { get; set; }
                public int Adults { get; set; }
                public int Children { get; set; }

                public class CancellationPolicy
                {
                    public string Amount { get; set; }
                    public string From { get; set; }
                }

                public class Breakdown
                {
                    public List<Supplements> RateSupplements { get; set; } = new();
                    public class Supplements
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

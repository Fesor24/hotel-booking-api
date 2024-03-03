namespace HB.Domain.Models.HotelBed;
public class HotelSearchResponse
{
    public HotelAuditResponse AuditData { get; set; } = new();
    public HotelData Hotels { get; set; } = new();

    public class HotelData
    {
        public List<HotelItemData> Hotels { get; set; } = new();
        public string CheckIn { get; set; }
        public string CheckOut { get; set; }
        public int Total { get; set; }

        public class HotelItemData
        {
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
            public List<HotelRoom> Rooms { get; set; } = new();

            public class HotelRoom
            {
                public string Code { get; set; }
                public string Name { get; set; }
                public List<HotelRoomRate> Rates { get; set; } = new();
                
                public class HotelRoomRate
                {
                    public string RateKey { get; set; }
                    public string RateClass { get; set; }
                    public string RateType { get; set; }
                    public string Net { get; set; }
                    public int Allotment { get; set; }
                    public string PaymentType { get; set; }
                    public bool Packaging { get; set; }
                    public string BoardCode { get; set; }
                    public string BoardName { get; set;}
                    public List<CancellationPolicy> CancellationPolicies { get;set; } = new();
                    public HotelRoomRateTax Taxes { get; set; }
                    public int Rooms { get; set; }
                    public int Adults { get; set; }
                    public int Children { get; set; }
                    public List<HotelRoomDailyRate> DailyRates { get; set; } = new();

                    public class HotelRoomRateTax
                    {
                        public List<HotelRoomRateTaxItem> Taxes { get; set; } = new();
                        public bool AllIncluded { get; set; }

                        public class HotelRoomRateTaxItem
                        {
                            public bool Included { get; set; }
                            public string Amount { get; set; }
                            public string Currency { get; set; }
                            public string ClientAmount { get; set; }
                            public string ClientCurrency { get; set; }
                        }
                    }

                    public class CancellationPolicy
                    {
                        public string Amount { get; set; }
                        public DateTime From { get; set; }
                    }

                    public class HotelRoomDailyRate
                    {
                        public int Offset { get; set; }
                        public string DailyNet { get; set; }
                    }
                }
            }
        }
    }
}

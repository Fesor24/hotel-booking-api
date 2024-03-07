using System.Text.Json.Serialization;

namespace HB.Domain.Models.HotelBed;
public class HotelsResponse
{
    public int From { get; set; }
    public int To { get; set; }
    public int Total { get; set; }
    public HotelAuditResponse AuditData { get; set; }
    public List<Hotel> Hotels { get; set; } = new();

    public class Hotel
    {
        public int Code { get; set; }
        public HotelName Name { get; set; }
        public HotelDescription Description { get; set; }
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
        public string DestinationCode { get; set; }
        public int ZoneCode { get; set; }
        public HotelCoordinates Coordinates { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryGroupCode { get; set; }
        public string ChainCode { get; set; }
        public string AccommodationTypeCode { get; set; }
        public List<string> BoardCodes { get; set; } = new();
        public List<int> SegmentCodes { get; set; } = new();
        public HotelAddress Address { get; set; } = new();
        public string PostalCode { get; set; }
        public HotelCity City { get; set; } = new();
        public string Email { get; set; }
        public string License { get; set; }
        public List<HotelPhones> Phones { get; set; } = new();
        public List<HotelRoom> Rooms { get; set; } = new();
        public List<Facility> Facilities { get; set; } = new();
        public List<Terminal> Terminals { get; set; } = new();
        public List<InterestPoint> InterestPoints { get; set; } = new();
        public List<Image> Images { get; set; } = new();
        public List<WildCard> WildCards { get; set; } = new();
        public string Web { get; set; }
        public string LastUpdate { get; set; }
        [JsonPropertyName("S2C")]
        public string S2C { get; set; }
        public int Ranking { get; set; }

        public class HotelName
        {
            public string Content { get; set; }
        }

        public class HotelDescription
        {
            public string Content { get; set; }
        }

        public class HotelCoordinates
        {
            public decimal Longitude { get; set; }
            public decimal Latitude { get; set; }
        }

        public class HotelAddress
        {
            public string Content { get; set; }
            public string Street { get; set; }
            public string Number { get; set; }
        }

        public class HotelCity
        {
            public string Content { get; set; }
        }

        public class HotelPhones
        {
            public string PhoneNumber { get; set; }
            public string PhoneType { get; set; }
        }

        public class HotelRoom
        {
            public string RoomCode { get; set; }
            public bool IsParentRoom { get; set; }
            public int MinPax { get; set; }
            public int MaxPax { get; set; }
            public int MaxAdults { get; set; }
            public int MaxChildren { get; set; }
            public int MinAdults { get; set; }
            public string RoomType { get; set; }
            public string CharacteristicCode { get; set; }
            public List<RoomFacility> RoomFacilities { get; set; } = new();
            public List<HotelRoomStay> RoomStays { get; set; } = new();

            public class RoomFacility
            {
                public int FacilityCode { get; set; }
                public int FacilityGroupCode { get; set; }
                public bool IndLogic { get; set; }
                public int Number { get; set; }
                public bool Voucher { get; set; }
            }
        }

        public class HotelRoomStay
        {
            public string StayType { get; set; }
            public string Order { get; set; }
            public string Description { get; set; }
            public List<RoomStayFacility> RoomStayFacilities { get; set; } = new();

            public class RoomStayFacility
            {
                public int FacilityCode { get; set; }
                public int FacilityGroupCode { get; set; }
                public int Number { get; set; }
            }
        }

        public class Facility
        {
            public int FacilityCode { get; set; }
            public int FacilityGroupCode { get; set; }
            public int Order { get; set; }
            public bool IndYesOrNo { get; set; }
            public int Number { get; set; }
            public bool Voucher { get; set; }
        }

        public class Terminal
        {
            public string TerminalCode { get; set; }
            public int Distance { get; set; }
        }

        public class InterestPoint
        {
            public int FacilityCode { get; set; }
            public int FacilityGroupCode { get; set; }
            public int Order { get; set; }
            public string PoiName { get; set; }
            public string Distance { get; set; }
        }

        public class Image
        {
            public string ImageTypeCode { get; set; }
            public string Path { get; set; }
            public int Order { get; set; }
            public int VisualOrder { get; set; }
        }

        public class WildCard
        {
            public string RoomType { get; set; }
            public string RoomCode { get; set; }
            public string CharacteristicCode { get; set; }
            public RoomDescription HotelRoomDescription { get; set; } = new();

            public class RoomDescription
            {
                public string Content { get; set; }
            }
        }
    }
}

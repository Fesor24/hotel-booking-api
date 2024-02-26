using HB.Domain.Shared;

namespace HB.Domain.Models.HotelBed;
public class HotelBedErrorResponse : BaseError
{
    public string Error { get; set; }
}

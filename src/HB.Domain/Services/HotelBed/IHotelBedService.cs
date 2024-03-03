using HB.Domain.Models.HotelBed;
using HB.Domain.Shared;

namespace HB.Domain.Services.HotelBed;
public interface IHotelBedService
{
    Task<Result<HotelBedStatusResponse, HotelBedErrorResponse>> CheckStatus();
    Task<Result<HotelSearchResponse, HotelBedErrorResponse>> Search(HotelSearch search);
    Task<Result<object, HotelBedErrorResponse>> GetHotels();
}

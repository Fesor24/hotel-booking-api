using HB.Domain.Models.HotelBed;
using HB.Domain.Shared;

namespace HB.Domain.Services.HotelBed;
public interface IHotelBedService
{
    Task<Result<HotelBedStatusResponse, HotelBedErrorResponse>> CheckStatus();
    Task<Result<HotelSearchResponse, HotelBedErrorResponse>> Search(HotelSearch search);
    Task<Result<object, HotelBedErrorResponse>> GetHotels(int from, int to);
    Task<Result<HotelLocationResponse, HotelBedErrorResponse>> GetLocations(int from, int to);
    Task<Result<HotelRateResponse, HotelBedErrorResponse>> CheckRates(HotelRate rate);
    Task<Result<HotelBookingConfirmationResponse, HotelBedErrorResponse>> ConfirmBooking(HotelBookingConfirmation confirmation);
}

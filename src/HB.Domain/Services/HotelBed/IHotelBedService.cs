using HB.Domain.Models.HotelBed;
using HB.Domain.Shared;

namespace HB.Domain.Services.HotelBed;
public interface IHotelBedService
{
    Task<Result<object, HotelBedErrorResponse>> CheckStatus();
}

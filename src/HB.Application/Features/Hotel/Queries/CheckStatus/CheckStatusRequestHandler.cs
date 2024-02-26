using HB.Domain.Models.HotelBed;
using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.CheckStatus;
internal sealed class CheckStatusRequestHandler : IRequestHandler<CheckStatusRequest,
    Result<object, HotelBedErrorResponse>>
{
    private readonly IHotelBedService _hotelBedService;

    public CheckStatusRequestHandler(IHotelBedService hotelBedService)
    {
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<object, HotelBedErrorResponse>> Handle(CheckStatusRequest request, 
        CancellationToken cancellationToken)
    {
        return await _hotelBedService.CheckStatus();
    }
}

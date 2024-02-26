using HB.Domain.Models.HotelBed;
using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.CheckStatus;
internal sealed class CheckStatusRequestHandler : IRequestHandler<CheckStatusRequest,
    Result<HotelBedStatusResponse, Error>>
{
    private readonly IHotelBedService _hotelBedService;

    public CheckStatusRequestHandler(IHotelBedService hotelBedService)
    {
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<HotelBedStatusResponse, Error>> Handle(CheckStatusRequest request, 
        CancellationToken cancellationToken)
    {
        var res =  await _hotelBedService.CheckStatus();

        if (res.IsFailure)
            return new Error("404", res.ErrorResult.Message, res.ErrorResult.Error);

        return res.Value;
    }
}

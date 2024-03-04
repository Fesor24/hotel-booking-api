using HB.Domain.Models.HotelBed;
using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.CheckRates;
internal sealed class CheckRateRequestHandler : IRequestHandler<CheckRateRequest, 
    Result<HotelRateResponse.HotelRate, Error>>
{
    private readonly IHotelBedService _hotelBedService;

    public CheckRateRequestHandler(IHotelBedService hotelBedService)
    {
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<HotelRateResponse.HotelRate, Error>> Handle(CheckRateRequest request, 
        CancellationToken cancellationToken)
    {
        HotelRate rate = new();

        foreach(var key in request.RateKeys)
        {
            rate.Rooms.Add(new HotelRate.Room { RateKey = key });
        }

        if (!rate.Rooms.Any())
            return new Error("400", "Enter at least one rate key", "");

        var res = await _hotelBedService.CheckRates(rate);

        if (res.IsFailure)
        {
            string errorDetails = string.IsNullOrWhiteSpace(res.ErrorResult.Error) ? res.ErrorResult.Details :
                res.ErrorResult.Error;

            return new Error("400", res.ErrorResult.Message, errorDetails);
        }

        return res.Value.Hotel;
    }
}

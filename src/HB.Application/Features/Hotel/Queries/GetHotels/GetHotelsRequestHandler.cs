using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.GetHotels;
internal sealed class GetHotelsRequestHandler : IRequestHandler<GetHotelsRequest, Result<object, Error>>
{
    private readonly IHotelBedService _hotelBedService;

    public GetHotelsRequestHandler(IHotelBedService hotelBedService)
    {
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<object, Error>> Handle(GetHotelsRequest request, CancellationToken cancellationToken)
    {
        var res = await _hotelBedService.GetHotels();

        if (res.IsFailure)
        {
            string errorDetails = string.IsNullOrWhiteSpace(res.ErrorResult.Error) ? res.ErrorResult.Details :
                res.ErrorResult.Error;

            return new Error("400", res.ErrorResult.Message, errorDetails);
        }

        return res.Value;
    }
}

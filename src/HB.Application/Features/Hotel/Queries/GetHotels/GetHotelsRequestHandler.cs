using HB.Domain.Models.HotelBed;
using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.GetHotels;
internal sealed class GetHotelsRequestHandler : IRequestHandler<GetHotelsRequest, Result<List<HotelsResponse.Hotel>, Error>>
{
    private readonly IHotelBedService _hotelBedService;

    public GetHotelsRequestHandler(IHotelBedService hotelBedService)
    {
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<List<HotelsResponse.Hotel>, Error>> Handle(GetHotelsRequest request, 
        CancellationToken cancellationToken)
    {
        var res = await _hotelBedService.GetHotels(request.From, request.To);

        if (res.IsFailure)
        {
            string errorDetails = string.IsNullOrWhiteSpace(res.ErrorResult.Error) ? res.ErrorResult.Details :
                res.ErrorResult.Error;

            return new Error("400", res.ErrorResult.Message, errorDetails);
        }

        return res.Value.Hotels;
    }
}

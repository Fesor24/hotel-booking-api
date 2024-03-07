using HB.Domain.Models.HotelBed;
using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.GetLocations;
internal sealed class GetLocationsRequestHandler : IRequestHandler<GetLocationsRequest, 
    Result<List<HotelLocationResponse.Country>, Error>>
{
    private readonly IHotelBedService _hotelBedService;

    public GetLocationsRequestHandler(IHotelBedService hotelBedService)
    {
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<List<HotelLocationResponse.Country>, Error>> Handle(GetLocationsRequest request, 
        CancellationToken cancellationToken)
    {
        var res = await _hotelBedService.GetLocations(request.From, request.To);

        if (res.IsFailure)
        {
            string errorDetails = string.IsNullOrWhiteSpace(res.ErrorResult.Error) ? res.ErrorResult.Details :
                res.ErrorResult.Error;

            return new Error("404", res.ErrorResult.Message, errorDetails);
        }

        return res.Value.Countries;
    }
}

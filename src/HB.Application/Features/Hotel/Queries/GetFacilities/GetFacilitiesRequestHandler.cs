using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.GetFacilities;
internal sealed class GetFacilitiesRequestHandler : IRequestHandler<GetFacilitiesRequest, Result<object, Error>>
{
    private readonly IHotelBedService _hotelBedService;

    public GetFacilitiesRequestHandler(IHotelBedService hotelBedService)
    {
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<object, Error>> Handle(GetFacilitiesRequest request, CancellationToken cancellationToken)
    {
        var res = await _hotelBedService.GetFacilities(request.From, request.To);

        if (res.IsFailure)
        {
            string errorMessage = string.IsNullOrWhiteSpace(res.ErrorResult.Error) ? res.ErrorResult.Details :
                res.ErrorResult.Error;

            return new Error("404", res.Error.Message, errorMessage);
        }

        return res.Value;
    }
}

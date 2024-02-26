using HB.Domain.Models.HotelBed;
using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.Search;
internal sealed class HotelSearchRequestHandler : IRequestHandler<HotelSearchRequest, Result<object, Error>>
{
    private readonly IHotelBedService _hotelBedService;

    public HotelSearchRequestHandler(IHotelBedService hotelBedService)
    {
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<object, Error>> Handle(HotelSearchRequest request, CancellationToken cancellationToken)
    {
        HotelSearch hotelSearch = new();

        if (request.Duration.CheckIn > request.Duration.CheckOut)
            return new Error("404", "Check in can not be after check out", "Check in can not be after check out");

        hotelSearch.Occupancies.Add(new HotelSearch.Occupancy
        {
            Adults = request.Occupants.Adults,
            Rooms = request.Occupants.Rooms,
            Children = request.Occupants.Children
        });

        hotelSearch.Stay = new()
        {
            CheckIn = request.Duration.CheckIn.ToString("yyyy-MM-dd"),
            CheckOut = request.Duration.CheckOut.ToString("yyyy-MM-dd")
        };

        var res = await _hotelBedService.Search(hotelSearch);

        string errorDetails = string.IsNullOrWhiteSpace(res.ErrorResult.Error) ? res.ErrorResult.Details :
            res.ErrorResult.Error;

        if (res.IsFailure)
            return new Error("404", res.ErrorResult.Message, errorDetails);

        return res.Value;
    }
}

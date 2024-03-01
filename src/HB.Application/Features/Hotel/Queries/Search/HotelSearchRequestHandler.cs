using HB.Domain.Models.HotelBed;
using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.Search;
internal sealed class HotelSearchRequestHandler : IRequestHandler<HotelSearchRequest, 
    Result<HotelSearchResponse, Error>>
{
    private readonly IHotelBedService _hotelBedService;

    public HotelSearchRequestHandler(IHotelBedService hotelBedService)
    {
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<HotelSearchResponse, Error>> Handle(HotelSearchRequest request, 
        CancellationToken cancellationToken)
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

        hotelSearch.Hotels.Hotel = request.HotelCodes;

        var res = await _hotelBedService.Search(hotelSearch);

        if (res.IsFailure)
        {
            string errorDetails = string.IsNullOrWhiteSpace(res.ErrorResult.Error) ? res.ErrorResult.Details :
            res.ErrorResult.Error;

            return new Error("404", res.ErrorResult.Message, errorDetails);
        }

        return res.Value;
    }
}

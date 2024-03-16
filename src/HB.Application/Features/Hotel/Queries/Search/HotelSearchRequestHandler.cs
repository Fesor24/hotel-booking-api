using HB.Domain.Entity.HotelAggregate;
using HB.Domain.Models.HotelBed;
using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.Search;
internal sealed class HotelSearchRequestHandler : IRequestHandler<HotelSearchRequest, 
    Result<SearchHotelResponse, Error>>
{
    private readonly IHotelBedService _hotelBedService;
    private readonly IHotelRepository _hotelRepository;

    public HotelSearchRequestHandler(IHotelBedService hotelBedService, IHotelRepository hotelRepository)
    {
        _hotelBedService = hotelBedService;
        _hotelRepository = hotelRepository;
    }

    public async Task<Result<SearchHotelResponse, Error>> Handle(HotelSearchRequest request, 
        CancellationToken cancellationToken)
    {
        if (request.Duration.CheckIn.Date < DateTime.UtcNow.Date)
            return new Error("404", "Check in must be a future date");

        if (request.Duration.CheckIn > request.Duration.CheckOut)
            return new Error("404", "Check in can not be after check out", "Check in can not be after check out");

        HotelSearch hotelSearch = new();

        var countryHotels = await _hotelRepository
            .GetAllByValueAsync(x => x.CountryCode, request.CountryCode.ToUpper());

        if (!countryHotels.Any())
            return new Error("404", "No hotel found for country code");

        List<int> countryCodes = countryHotels.Select(x => x.Code)
            .ToList();

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

        hotelSearch.Hotels.Hotel = countryCodes;

        var res = await _hotelBedService.Search(hotelSearch);

        if (res.IsFailure)
        {
            string errorDetails = string.IsNullOrWhiteSpace(res.ErrorResult.Error) ? res.ErrorResult.Details :
            res.ErrorResult.Error;

            return new Error("404", res.ErrorResult.Message, errorDetails);
        }

        SearchHotelResponse response = new(res.Value.Hotels, new SearchMeta(request.Duration, request.Occupants));

        return response;
    }
}

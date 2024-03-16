using HB.Domain.Models.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.Search;
public record HotelSearchRequest(
    string CountryCode,
    HotelSearchDuration Duration,
    HotelSearchOccupants Occupants
    ) : IRequest<Result<SearchHotelResponse, Error>>;

public record HotelSearchDuration(
    DateTime CheckIn,
    DateTime CheckOut
    );

public record HotelSearchOccupants(
    int Adults = 1,
    int Rooms = 1,
    int Children = 0
    );

public record SearchHotelResponse(
    HotelSearchResponse.HotelData Hotels,
    SearchMeta Meta
    );

public record SearchMeta(
    HotelSearchDuration Duration,
    HotelSearchOccupants Occupants
    );

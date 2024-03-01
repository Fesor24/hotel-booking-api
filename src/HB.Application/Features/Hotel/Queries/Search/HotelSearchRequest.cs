using HB.Domain.Models.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.Search;
public record HotelSearchRequest(
    HotelSearchDuration Duration,
    HotelSearchOccupants Occupants,
    List<int> HotelCodes
    ) : IRequest<Result<HotelSearchResponse, Error>>;

public record HotelSearchDuration(
    DateTime CheckIn,
    DateTime CheckOut
    );

public record HotelSearchOccupants(
    int Adults = 1,
    int Rooms = 1,
    int Children = 0
    );

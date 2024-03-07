using HB.Domain.Models.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.GetLocations;
public record GetLocationsRequest(int From, int To) : 
    IRequest<Result<List<HotelLocationResponse.Country>, Error>>;

using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.GetHotels;
public record GetHotelsRequest() : 
    IRequest<Result<List<HotelEntity>, Error>>;

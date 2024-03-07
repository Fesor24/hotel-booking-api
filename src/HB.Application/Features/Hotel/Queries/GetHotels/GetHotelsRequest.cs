using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.GetHotels;
public record GetHotelsRequest(int From, int To) : 
    IRequest<Result<object, Error>>;

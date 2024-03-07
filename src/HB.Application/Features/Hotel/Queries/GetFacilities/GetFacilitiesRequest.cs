using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Queries.GetFacilities;
public record GetFacilitiesRequest(int From, int To) : IRequest<Result<object, Error>>;

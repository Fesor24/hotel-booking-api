using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Country.Queries;
public record GetCountriesRequest : IRequest<Result<List<GetCountryResponse>, Error>>;

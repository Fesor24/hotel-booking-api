using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Country.Commands.Create;
public record CreateCountryCommand() : IRequest<Result<string, Error>>;

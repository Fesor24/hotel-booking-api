using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Country.Commands.Create;
public record CreateCountryCommand(int From, int To) : 
    IRequest<Result<bool, Error>>;

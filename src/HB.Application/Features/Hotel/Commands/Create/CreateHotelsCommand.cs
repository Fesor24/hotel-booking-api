using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Hotel.Commands.Create;
public sealed record CreateHotelsCommand(int From, int To) : IRequest<Result<bool, Error>>;

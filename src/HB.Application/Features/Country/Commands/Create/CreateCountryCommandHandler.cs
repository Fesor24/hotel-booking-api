using HB.Domain.Entity.CountryAggregate;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Country.Commands.Create;
internal sealed class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<string, Error>>
{
    private readonly ICountryRepository _countryRepository;

    public CreateCountryCommandHandler(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    public async Task<Result<string, Error>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        await _countryRepository.AddAsync(new Domain.Entity.CountryAggregate.Country
        {
            Name = "Nigeria",
            Code = "NG",
        });

        return "";
    }
}

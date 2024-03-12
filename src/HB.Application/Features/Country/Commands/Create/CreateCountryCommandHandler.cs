using HB.Domain.Entity.CountryAggregate;
using HB.Domain.Services.HotelBed;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Country.Commands.Create;
internal sealed class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<bool, Error>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IHotelBedService _hotelBedService;

    public CreateCountryCommandHandler(ICountryRepository countryRepository, IHotelBedService hotelBedService)
    {
        _countryRepository = countryRepository;
        _hotelBedService = hotelBedService;
    }

    public async Task<Result<bool, Error>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var res = await _hotelBedService.GetLocations(request.From, request.To);

        if (res.IsFailure)
        {
            string errorMessage = string.IsNullOrWhiteSpace(res.ErrorResult.Error) ? res.ErrorResult.Details :
                res.ErrorResult.Error;

            return new Error("400", res.ErrorResult.Message, errorMessage);
        }

        List<CountryEntity> countries = new();

        foreach (var location in res.Value.Countries)
        {
            List<State> states = new();

            foreach(var item in location.States)
            {
                State state = new()
                {
                    Name = item.Name,
                    Code = item.Code
                };

                states.Add(state);
            }

            CountryEntity country = new()
            {
                Code = location.Code,
                Name = location.Description.Content,
                States = states
            };

            countries.Add(country);
        }

        await _countryRepository.AddRangeAsync(countries);

        return true;
    }
}

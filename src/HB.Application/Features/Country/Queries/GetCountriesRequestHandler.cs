using AutoMapper;
using HB.Domain.Entity.CountryAggregate;
using HB.Domain.Shared;
using MediatR;

namespace HB.Application.Features.Country.Queries;
internal sealed class GetCountriesRequestHandler : IRequestHandler<GetCountriesRequest, 
    Result<List<GetCountryResponse>, Error>>
{
    private readonly ICountryRepository _countryRepository;
    private readonly IMapper _mapper;

    public GetCountriesRequestHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
    }

    public async Task<Result<List<GetCountryResponse>, Error>> Handle(GetCountriesRequest request, 
        CancellationToken cancellationToken)
    {
        var countries = await _countryRepository.GetAllAsync();

        return _mapper.Map<List<GetCountryResponse>>(countries);
    }
}

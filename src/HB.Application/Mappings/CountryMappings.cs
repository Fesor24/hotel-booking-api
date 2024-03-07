using AutoMapper;
using HB.Application.Features.Country.Queries;
using HB.Domain.Entity.CountryAggregate;

namespace HB.Application.Mappings;
public class CountryMappings : Profile
{
    public CountryMappings()
    {
        CreateMap<Country, GetCountryResponse>();
    }
}

using HB.Domain.Primitives;
using HB.Shared.Markers;

namespace HB.Domain.Entity.CountryAggregate;
public interface ICountryRepository : IGenericRepository<Country>, IScopedService
{
}

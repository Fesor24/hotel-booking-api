using HB.Domain.Entity.CountryAggregate;
using HB.Infrastructure.Data;

namespace HB.Infrastructure.Repository;
public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    public CountryRepository(HotelDbContext context) : base(context.Country)
    {
        
    }
}

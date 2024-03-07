using HB.Domain.Entity.CountryAggregate;
using MongoDB.Driver;

namespace HB.Infrastructure.Data;
public class HotelDbContext
{
    private readonly IMongoDatabase _db;
    private IMongoCollection<Country> _country;

    public HotelDbContext(IMongoDatabase db)
    {
        _db = db;
    }

    public IMongoCollection<Country> Country { get
        {
            _country ??= _db.GetCollection<Country>(nameof(Country));

            return _country;
        } 
    }
}

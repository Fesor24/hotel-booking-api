using HB.Domain.Entity.CountryAggregate;
using HB.Domain.Entity.HotelAggregate;
using MongoDB.Driver;

namespace HB.Infrastructure.Data;
public class HotelDbContext
{
    private readonly IMongoDatabase _db;
    private IMongoCollection<Country> _country;
    private IMongoCollection<Hotel> _hotel;

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

    public IMongoCollection<Hotel> Hotel
    {
        get
        {
            _hotel ??= _db.GetCollection<Hotel>(nameof(Hotel));

            return _hotel;
        }
    }
}

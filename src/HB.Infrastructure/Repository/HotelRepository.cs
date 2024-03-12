using HB.Domain.Entity.HotelAggregate;
using MongoDB.Driver;

namespace HB.Infrastructure.Repository;
internal class HotelRepository : GenericRepository<Hotel>, IHotelRepository
{
    public HotelRepository(IMongoCollection<Hotel> collection) : base(collection)
    {
        
    }
}

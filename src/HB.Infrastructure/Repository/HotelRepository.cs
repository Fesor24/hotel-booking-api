using HB.Domain.Entity.HotelAggregate;
using HB.Infrastructure.Data;
using MongoDB.Driver;

namespace HB.Infrastructure.Repository;
public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
{
    public HotelRepository(HotelDbContext context) : base(context.Hotel)
    {
        
    }
}

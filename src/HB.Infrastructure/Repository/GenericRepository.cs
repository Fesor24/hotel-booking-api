using HB.Domain.Primitives;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HB.Infrastructure.Repository;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
{
    private readonly IMongoCollection<TEntity> _collection;

    public GenericRepository(IMongoCollection<TEntity> collection) => _collection = collection;

    public async Task AddAsync(TEntity entity) => 
        await _collection.InsertOneAsync(entity);

    public async Task AddRangeAsync(IEnumerable<TEntity> entities) =>
        await _collection.InsertManyAsync(entities);

    public async Task<List<TEntity>> GetAllAsync()
    {
        var filter = Builders<TEntity>.Filter.Empty;

        return await _collection.Find(filter)
            .ToListAsync();
    }

    public async Task<List<TEntity>> GetAllByValueAsync<TField>
        (Expression<Func<TEntity, TField>> criteria, TField value)
    {
        var filter = Builders<TEntity>.Filter
            .Eq(criteria, value);

        return await _collection.Find(filter)
            .ToListAsync();
    }
}

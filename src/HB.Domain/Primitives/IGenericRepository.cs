using System.Linq.Expressions;

namespace HB.Domain.Primitives;
public interface IGenericRepository<TEntity> where TEntity: BaseEntity
{
    Task AddAsync(TEntity entity);
    Task AddRangeAsync(IEnumerable<TEntity> entities);
    Task<List<TEntity>> GetAllAsync();
    Task<List<TEntity>> GetAllByValueAsync<TField>
        (Expression<Func<TEntity, TField>> criteria, TField value);
}

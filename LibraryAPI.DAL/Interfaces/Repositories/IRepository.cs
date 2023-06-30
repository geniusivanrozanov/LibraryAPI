using System.Linq.Expressions;
using LibraryAPI.DAL.Interfaces.Entities;

namespace LibraryAPI.DAL.Interfaces.Repositories;

public interface IRepository<TEntity, in TKey>
    where TEntity : class, IBaseEntity<TKey>
{
    IQueryable<TProjection> Get<TProjection>();

    IQueryable<TProjection> Get<TProjection>(Expression<Func<TEntity, bool>> condition);

    Task<TProjection?> Get<TProjection>(TKey id);

    void Create(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<bool> ExistsAsync(TKey id);
}
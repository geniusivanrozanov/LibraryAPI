using System.Linq.Expressions;
using LibraryAPI.DAL.Interfaces.Entities;

namespace LibraryAPI.DAL.Interfaces.Repositories;

public interface IRepository<TEntity, TKey>
    where TEntity : class, IBaseEntity<TKey>
{
    IQueryable<TEntity> Get();

    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition);

    void Create(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<bool> ExistsAsync(TKey id);
}
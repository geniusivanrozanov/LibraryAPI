using System.Linq.Expressions;
using LibraryAPI.DAL.Interfaces.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Repositories;

public abstract class Repository<TEntity, TKey, TContext> : IRepository<TEntity, TKey>
    where TEntity : class, IBaseEntity<TKey>
    where TContext : DbContext
{
    protected readonly TContext Context;

    protected Repository(TContext context)
    {
        Context = context;
    }

    public virtual IQueryable<TEntity> Get() => Context.Set<TEntity>();

    public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition) => Get().Where(condition);

    public virtual void Create(TEntity entity) => Context.Set<TEntity>().Add(entity);

    public virtual void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    public virtual void Delete(TEntity entity) => Context.Set<TEntity>().Remove(entity);

    public virtual async Task<bool> ExistsAsync(TKey id) => await Context.Set<TEntity>().AnyAsync(e => e.Id.Equals(id));
}
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

    public IQueryable<TEntity> Get() => Context.Set<TEntity>();

    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition) => Context.Set<TEntity>().Where(condition);

    public void Create(TEntity entity) => Context.Set<TEntity>().Add(entity);

    public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity) => Context.Set<TEntity>().Remove(entity);
}
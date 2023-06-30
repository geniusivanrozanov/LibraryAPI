using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LibraryAPI.DAL.Interfaces.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql.TypeMapping;

namespace LibraryAPI.DAL.Repositories;

public abstract class Repository<TEntity, TKey, TContext> : IRepository<TEntity, TKey>
    where TEntity : class, IBaseEntity<TKey>
    where TContext : DbContext
{
    protected readonly TContext Context;
    protected readonly IMapper Mapper;
    
    protected DbSet<TEntity> Set => Context.Set<TEntity>();

    protected Repository(TContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    public virtual IQueryable<TProjection> Get<TProjection>()
    {
        if (typeof(TProjection) == typeof(TEntity))
        {
            return (IQueryable<TProjection>)Set;
        }

        return Set
            .AsNoTracking()
            .ProjectTo<TProjection>(Mapper.ConfigurationProvider);
    }

    public virtual IQueryable<TProjection> Get<TProjection>(Expression<Func<TEntity, bool>> condition)
    {
        var query = Set.Where(condition);
        if (typeof(TProjection) == typeof(TEntity))
        {
            return (IQueryable<TProjection>)query;
        }
        
        return query
            .AsNoTracking()
            .ProjectTo<TProjection>(Mapper.ConfigurationProvider);
    }

    public virtual async Task<TProjection?> Get<TProjection>(TKey id)
    {
        if (typeof(TProjection) != typeof(TEntity))
        {
            return await Get<TProjection>(e => e.Id.Equals(id)).SingleOrDefaultAsync();
        }
        
        var entity = await Set.FindAsync(id);
        return Mapper.Map<TProjection>(entity);

    }

    public virtual void Create(TEntity entity) => Set.Add(entity);

    public virtual void Update(TEntity entity) => Set.Update(entity);

    public virtual void Delete(TEntity entity) => Set.Remove(entity);

    public virtual async Task<bool> ExistsAsync(TKey id) => await Set.AnyAsync(e => e.Id.Equals(id));
}
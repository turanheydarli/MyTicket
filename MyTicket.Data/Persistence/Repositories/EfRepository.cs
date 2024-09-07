using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyTicket.Data.Models;

namespace MyTicket.Data.Persistence.Repositories;

public class EfRepository<TEntity, TContext> : IRepository<TEntity, TContext>
    where TEntity : BaseEntity
    where TContext : DbContext

{
    protected TContext Context { get; }

    public EfRepository(TContext context)
    {
        Context = context;
    }

    public IQueryable<TEntity?> Query()
    {
        return Context.Set<TEntity>();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().FirstOrDefault(predicate);
    }

    public TEntity? Get(Expression<Func<TEntity?, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity?> queryable = Query();
        if (include != null) queryable = include(queryable!);

        return queryable.FirstOrDefault(predicate);
    }

    public IList<TEntity?> GetList(Expression<Func<TEntity?, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity?> queryable = Query();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);

        return queryable.ToList();
    }

    public TEntity Add(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        Context.SaveChanges();
        return entity;
    }
}
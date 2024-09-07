using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyTicket.Data.Models;

namespace MyTicket.Data.Persistence.Repositories;

public interface IRepository<TEntity, TContext> where TContext : DbContext
    where TEntity : BaseEntity
{
    TEntity? Get(Expression<Func<TEntity?, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

    IList<TEntity?> GetList(Expression<Func<TEntity?, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
}
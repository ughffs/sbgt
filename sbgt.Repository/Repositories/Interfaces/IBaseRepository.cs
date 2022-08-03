using System.Linq.Expressions;
using sbgt.Repository.Entities;

namespace sbgt.Repository.Repositories.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAll();
    Task<TEntity?> GetById(Guid id);
    Task<TEntity> AddItem(TEntity entity);
    Task<TEntity?> GetByIdWithNavigationProperties(Guid id, params Expression<Func<TEntity, object>>[] exprs);
    Task SaveChanges(CancellationToken tok);
}
using System.Linq.Expressions;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Base.Specifications;

namespace EventModular.Shared.Base.Repositories;

public interface IBaseRepository<TEntity>
    where TEntity : class, IBaseEntity
{
    Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken);
    Task<List<TEntity>> CreateRange(List<TEntity> entities, CancellationToken cancellationToken);

    Task<TEntity> Update(Guid id, TEntity entity, CancellationToken cancellationToken);

    Task Delete(Guid id, CancellationToken cancellationToken);
    Task Delete(List<TEntity> entities, CancellationToken cancellationToken);

    Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAllAsNoTracking();

    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

    // Specification Pattern
    IQueryable<TEntity> Find(ISpecification<TEntity> specification);
    Task<List<TEntity>> FindAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
}

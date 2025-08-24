using System.Linq.Expressions;
using EventModular.Shared.Base.Entities;
using EventModular.Shared.Base.Specifications;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Shared.Base.Repositories;

public class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
    where TContext : DbContext
    where TEntity : class, IBaseEntity, new()
{
    protected readonly TContext _dbContext;

    public BaseRepository(TContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<List<TEntity>> CreateRange(List<TEntity> entities, CancellationToken cancellationToken)
    {
        await _dbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entities;
    }

    public async Task<TEntity> Update(Guid id, TEntity entity, CancellationToken cancellationToken)
    {
        var tracked = await _dbContext.Set<TEntity>().FindAsync([id], cancellationToken);
        if (tracked is null)
            throw new InvalidOperationException($"Entity {typeof(TEntity).Name} not found");

        _dbContext.Entry(tracked).CurrentValues.SetValues(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync([id], cancellationToken);
        if (entity is null) return;

        entity.IsArchived = true;
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task Delete(List<TEntity> entities, CancellationToken cancellationToken)
    {
        foreach (var entity in entities)
        {
            entity.IsArchived = true;
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>()
            .FirstOrDefaultAsync(e => e.Id == id && !e.IsArchived, cancellationToken);
    }

    public async Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync([id], cancellationToken);
        return (entity != null && !entity.IsArchived) ? entity : null;
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbContext.Set<TEntity>().Where(e => !e.IsArchived);
    }

    public IQueryable<TEntity> GetAllAsNoTracking()
    {
        return _dbContext.Set<TEntity>().AsNoTracking().Where(e => !e.IsArchived);
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return _dbContext.Set<TEntity>().Where(predicate).Where(e => !e.IsArchived);
    }

    // Specification Pattern
    public IQueryable<TEntity> Find(ISpecification<TEntity> specification)
    {
        var query = _dbContext.Set<TEntity>().AsQueryable();
        query = SpecificationEvaluator<TEntity>.GetQuery(query, specification);
        return query.Where(e => !e.IsArchived);
    }

    public async Task<List<TEntity>> FindAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        var query = SpecificationEvaluator<TEntity>.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), specification)
                                                   .Where(e => !e.IsArchived);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        var query = SpecificationEvaluator<TEntity>.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), specification)
                                                   .Where(e => !e.IsArchived);
        return await query.CountAsync(cancellationToken);
    }

    public async Task<TEntity?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        var query = SpecificationEvaluator<TEntity>.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), specification)
                                                   .Where(e => !e.IsArchived);
        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        var query = SpecificationEvaluator<TEntity>.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), specification)
                                                   .Where(e => !e.IsArchived);
        return await query.AnyAsync(cancellationToken);
    }
}

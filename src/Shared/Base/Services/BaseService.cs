using EventModular.Shared.Base.Entities;
using EventModular.Shared.Base.Repositories;
using EventModular.Shared.Base.Specifications;
using EventModular.Shared.Constants.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Shared.Base.Services;

public class BaseService<TEntity, TInput, TOutput> : IBaseService<TEntity, TInput, TOutput>
       where TEntity : class, IBaseEntity, new()
       where TInput : class
       where TOutput : class, new()
{
    protected readonly IBaseRepository<TEntity> _repository;

    public BaseService(IBaseRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public virtual async Task<SingleResponse<TEntity>> Create(TInput input, CancellationToken cancellationToken)
    {
        var entity = input.Adapt<TEntity>();
        await _repository.Create(entity, cancellationToken);
        return entity.Id != Guid.Empty ? SingleResponse<TEntity>.Success(entity) : ResponseStatus.UnknownError;
    }

    public virtual async Task<SingleResponse<TCustomEntity>> Create<TCustomEntity, TCustomInput>(TCustomInput input, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity, new()
        where TCustomInput : class
    {
        var entity = input.Adapt<TCustomEntity>();
        var repo = (IBaseRepository<TCustomEntity>)_repository;
        await repo.Create(entity, cancellationToken);
        return entity.Id != Guid.Empty ? SingleResponse<TCustomEntity>.Success(entity) : ResponseStatus.UnknownError;
    }

    public virtual async Task<SingleResponse<TEntity>> Update(Guid id, TInput input, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(id, cancellationToken);
        if (entity == null)
            return ResponseStatus.NotFound;

        input.Adapt(entity);
        await _repository.Update(id, entity, cancellationToken);
        return SingleResponse<TEntity>.Success(entity);
    }

    public virtual async Task<SingleResponse<TCustomEntity>> Update<TCustomEntity, TCustomInput>(Guid id, TCustomInput input, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity, new()
        where TCustomInput : class
    {
        var repo = (IBaseRepository<TCustomEntity>)_repository;
        var entity = await repo.GetById(id, cancellationToken);
        if (entity == null)
            return ResponseStatus.NotFound;

        input.Adapt(entity);
        await repo.Update(id, entity, cancellationToken);
        return SingleResponse<TCustomEntity>.Success(entity);
    }

    public virtual async Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(id, cancellationToken);
        if (entity == null)
            return ResponseStatus.NotFound;

        await _repository.Delete(id, cancellationToken);
        return ResponseStatus.Success;
    }

    public virtual async Task<JustResponse> Delete<TCustomEntity>(Guid id, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity, new()
    {
        var repo = (IBaseRepository<TCustomEntity>)_repository;
        var entity = await repo.GetById(id, cancellationToken);
        if (entity == null)
            return ResponseStatus.NotFound;

        await repo.Delete(entity.Id, cancellationToken);
        return ResponseStatus.Success;
    }

    public virtual async Task<JustResponse> Delete(List<TEntity> entities, CancellationToken cancellationToken)
    {
        await _repository.Delete(entities, cancellationToken);
        return ResponseStatus.Success;
    }

    public virtual async Task<SingleResponse<TOutput>> Get(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetById(id, cancellationToken);
        return entity == null ? ResponseStatus.NotFound : SingleResponse<TOutput>.Success(entity.Adapt<TOutput>());
    }

    public virtual async Task<ListResponse<TOutput>> Get(CancellationToken cancellationToken)
    {
        var entities = await _repository.GetAll().ToListAsync(cancellationToken);
        var result = entities.Adapt<List<TOutput>>();
        return ListResponse<TOutput>.Success(result);
    }

    // Specification Pattern
    public virtual async Task<ListResponse<TOutput>> FindAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        var entities = await _repository.FindAsync(specification, cancellationToken);
        var result = entities.Adapt<List<TOutput>>();
        return ListResponse<TOutput>.Success(result);
    }

    public virtual async Task<ListResponse<TOutput>> Find(ISpecification<TEntity> specification, CancellationToken cancellationToken)
    {
        var entities = await _repository.FindAsync(specification, cancellationToken);
        var result = entities.Adapt<List<TOutput>>();
        return ListResponse<TOutput>.Success(result);
    }

}

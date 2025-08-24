using EventModular.Shared.Base.Entities;
using EventModular.Shared.Base.Specifications;
using EventModular.Shared.Constants.Response;

namespace EventModular.Shared.Base.Services;

public interface IBaseService<TEntity, TInput, TOutput>
       where TEntity : class, IBaseEntity, new()
       where TInput : class
       where TOutput : class, new()
{
    Task<SingleResponse<TEntity>> Create(TInput input, CancellationToken cancellationToken);
    Task<SingleResponse<TCustomEntity>> Create<TCustomEntity, TCustomInput>(TCustomInput input, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity, new()
        where TCustomInput : class;

    Task<SingleResponse<TEntity>> Update(Guid id, TInput input, CancellationToken cancellationToken);
    Task<SingleResponse<TCustomEntity>> Update<TCustomEntity, TCustomInput>(Guid id, TCustomInput input, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity, new()
        where TCustomInput : class;

    Task<JustResponse> Delete(Guid id, CancellationToken cancellationToken);
    Task<JustResponse> Delete<TCustomEntity>(Guid id, CancellationToken cancellationToken)
        where TCustomEntity : class, IBaseEntity, new();
    Task<JustResponse> Delete(List<TEntity> entities, CancellationToken cancellationToken);

    Task<SingleResponse<TOutput>> Get(Guid id, CancellationToken cancellationToken);
    Task<ListResponse<TOutput>> Get(CancellationToken cancellationToken);

    // Specification Pattern
    Task<ListResponse<TOutput>> FindAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<ListResponse<TOutput>> Find(ISpecification<TEntity> specification, CancellationToken cancellationToken);

    Task<SingleResponse<TOutput>> GetSingleAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
    Task<bool> ExistsAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken);
}

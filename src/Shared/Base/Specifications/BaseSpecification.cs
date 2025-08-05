using System.Linq.Expressions;

namespace EventModular.Shared.Base.Specifications;
public abstract class BaseSpecification<TEntity> : ISpecification<TEntity>
{
    public Expression<Func<TEntity, bool>>? Criteria { get; protected set; }

    public List<Expression<Func<TEntity, object>>> Includes { get; } = new();

    public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
    public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }

    public int? Take { get; private set; }
    public int? Skip { get; private set; }
    public bool IsPagingEnabled => Skip.HasValue && Take.HasValue;

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }

    public virtual bool IsSatisfiedBy(TEntity entity)
    {
        if (Criteria is null) return true;
        return Criteria.Compile().Invoke(entity);
    }
}

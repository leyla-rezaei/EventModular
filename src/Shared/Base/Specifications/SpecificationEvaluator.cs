using Microsoft.EntityFrameworkCore;

namespace EventModular.Shared.Base.Specifications;
public static class SpecificationEvaluator<TEntity>
    where TEntity : class
{
    public static IQueryable<TEntity> GetQuery(
        IQueryable<TEntity> inputQuery,
        ISpecification<TEntity> specification)
    {
        var query = inputQuery;

        // Filter
        if (specification.Criteria is not null)
            query = query.Where(specification.Criteria);

        // Include
        foreach (var include in specification.Includes)
            query = query.Include(include);

        // Order By
        if (specification.OrderBy is not null)
            query = query.OrderBy(specification.OrderBy);

        if (specification.OrderByDescending is not null)
            query = query.OrderByDescending(specification.OrderByDescending);

        // Paging
        if (specification.IsPagingEnabled)
        {
            if (specification.Skip.HasValue)
                query = query.Skip(specification.Skip.Value);

            if (specification.Take.HasValue)
                query = query.Take(specification.Take.Value);
        }

        return query;
    }
}

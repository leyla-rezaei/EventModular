using Microsoft.EntityFrameworkCore;

namespace EventModular.Shared.Abstractions.Persistence;
public interface IApplicationDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}


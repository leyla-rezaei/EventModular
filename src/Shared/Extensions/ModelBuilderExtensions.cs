using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EventModular.Shared.Extensions;
public static class ModelBuilderExtensions
{
    public static void RegisterAllEntities<TBaseEntity>(this ModelBuilder modelBuilder, Assembly assembly)
    {
        var entityTypes = assembly.GetTypes()
            .Where(t => typeof(TBaseEntity).IsAssignableFrom(t) &&
                        t.IsClass &&
                        !t.IsAbstract &&
                        t.IsPublic)
            .ToList();

        foreach (var type in entityTypes)
        {
            modelBuilder.Entity(type);
        }
    }
}

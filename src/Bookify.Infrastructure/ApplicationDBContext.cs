using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure;

public sealed class ApplicationDBContext : DbContext, IUnitOfWork
{
    public ApplicationDBContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}

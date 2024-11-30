using Bookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure;

public sealed class ApplicationDBContext : DbContext, IUnitOfWork
{
    public ApplicationDBContext(DbContextOptions options)
        : base(options)
    {
    }
}

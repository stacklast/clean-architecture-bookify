using Bookify.Domain.Apartments;

namespace Bookify.Infrastructure.Repositories;

internal sealed class ApartmentRepository : Repository<Apartment>, IApartamentRepository
{
    public ApartmentRepository(ApplicationDBContext dbContext)
        : base(dbContext)
    {
    }
}
using Bookify.Domain.Abstractions;

namespace Bookify.Domain.UnitTests.Infrastructure;

public abstract class BaseTests
{
    public static T AssertDomainEventPublished<T>(Entity entity)
        where T : IDomainEvent
    {
        var domainEvent = entity.GetDomainEvents().OfType<T>().SingleOrDefault();

        if (domainEvent == null)
        {
            throw new Exception($"{typeof(T).Name} was not published.");
        }

        return domainEvent;
    }
}

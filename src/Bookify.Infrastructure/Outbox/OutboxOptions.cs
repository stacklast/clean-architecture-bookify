namespace Bookify.Infrastructure.Outbox;

public sealed class OutboxOptions
{
    public int IntervalInSeconds { get; init; } = 1;

    public int BatchSize { get; init; }
}

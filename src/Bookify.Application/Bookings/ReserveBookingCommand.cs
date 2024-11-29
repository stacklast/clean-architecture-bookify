using Bookify.Application.Abstractions.Messaging;

namespace Bookify.Application.Bookings;

public record ReserveBookingCommand(
    Guid ApartamentId,
    Guid UserId,
    DateOnly StartDate,
    DateOnly EndDate) : ICommand<Guid>
{
}

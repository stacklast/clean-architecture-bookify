using Bookify.Application.Abstractions.Clock;
using Bookify.Application.Abstractions.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, IDateTimeProvider>();

        services.AddTransient<IEmailService, IEmailService>();

        return services;
    }
}

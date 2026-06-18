using DepoFlow.Auth.Application.Abstractions;
using DepoFlow.Auth.Domain.Abstractions;
using DepoFlow.Auth.Infrastructure.Clock;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DepoFlow.Auth.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        #region DB
        var connectionString = configuration.GetConnectionString("DBDepoFlow")
             ?? throw new InvalidOperationException("No se encontró la cadena de conexión DBDepoFlow.");

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString,
            sql =>
            {
                sql.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            })
        );
        #endregion
        #region Providers
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        #endregion

        return services;
    }
}
using System;
using GraphQL.Types;
using GraphQlTypes.Schemas;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

namespace GraphQlWebCore.DependencyInjection;

/// <summary>
/// Extension methods for the registration of interfaces for DI in an <see cref="IServiceCollection" />.
/// </summary>
public static class RegisterServicesExtensions
{
    /// <summary>
    /// Adds DI-registrations to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    public static IServiceCollection AddRegistration(this IServiceCollection services)
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
        services.AddSingleton<ISchema, EmployeeSchema>();

        return services;
    }
}
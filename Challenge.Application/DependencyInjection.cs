using Challenge.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        
        return services;
    }
}
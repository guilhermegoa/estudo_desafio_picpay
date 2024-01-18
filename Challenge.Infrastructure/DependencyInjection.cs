using Challenge.Domain.Abstractions;
using Challenge.Infrastructure.Data;
using Challenge.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Challenge.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<SqlLiteContext>(options => 
            options.UseSqlite("Data Source=SqlLite/Application.db;Cache=Shared"));

        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}
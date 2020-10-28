using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Infrastructure.Data;
using ProjectManager.Infrastructure.Data.Interfaces;
using ProjectManager.Team.Services;

namespace ProjectManager.Team.Configuration
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddTransient<IDatabaseConnectionFactory>(e =>
            {
                return new DatabaseConnectionFactory(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<TeamServices>();

            return services;
        }
    }
}

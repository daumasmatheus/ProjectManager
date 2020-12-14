using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Infrastructure.Data.DatabaseContext;

namespace ProjectManager.API.Configuration
{
    public static class DbContextConfiguration
    {
        public static IServiceCollection AddMainDbContextConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );

            return services;
        }
    }
}

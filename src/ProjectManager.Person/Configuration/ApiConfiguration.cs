using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectManager.Infrastructure.Data;
using ProjectManager.Infrastructure.Data.Interfaces;
using ProjectManager.Person.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Person.Configuration
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddTransient<IDatabaseConnectionFactory>(e => {
                return new DatabaseConnectionFactory(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<PersonServices>();

            return services;
        }        
    }
}

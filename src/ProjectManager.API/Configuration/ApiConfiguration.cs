using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectManager.Core.Services.Implementations;
using ProjectManager.Core.Services.Interfaces;
using ProjectManager.Infrastructure.Repository.Implementations;
using ProjectManager.Infrastructure.Repository.Interfaces;

namespace ProjectManager.API.Configuration
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiConfiguration (this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }

        public static IServiceCollection AddCIConfiguration (this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration (this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseIdentityConfiguration();
            app.UseRouting();
            app.UseEndpoints(e =>
            {
                e.MapControllers();
            });

            return app;
        }
    }
}

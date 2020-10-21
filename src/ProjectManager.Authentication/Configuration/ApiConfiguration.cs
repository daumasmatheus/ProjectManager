using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectManager.Authentication.Services;

namespace ProjectManager.Authentication.Configuration
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddApiConfiguration (this IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<AuthenticationService>();

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

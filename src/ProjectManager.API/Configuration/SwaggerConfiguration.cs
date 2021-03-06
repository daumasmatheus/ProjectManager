﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace ProjectManager.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "ProjectManager API",
                    Description = "API da aplicação ProjectManager",
                    Contact = new OpenApiContact() { Name = "Matheus Daumas", Email = "daumasmatheus@gmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
                { 
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    c.RoutePrefix = string.Empty;
                }
            );

            return app;
        }
    }
}

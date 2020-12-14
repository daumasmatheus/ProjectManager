using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Infrastructure.Data.DatabaseContext;
using ProjectManager.Infrastructure.Repository.Implementations;
using ProjectManager.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProjectManager.Infrastructure.Tests
{
    public class Startup
    {
        private IConfiguration configuration;

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(Assembly.Load("ProjectManager.API")).AddControllersAsServices();

            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TaskManager;Trusted_Connection=True;MultipleActiveResultSets=true")
            );

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}

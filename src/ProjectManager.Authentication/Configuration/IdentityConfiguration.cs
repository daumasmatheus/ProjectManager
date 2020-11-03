using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjectManager.Authentication.Data;
using ProjectManager.Authentication.Extensions;
using System.Text;

namespace ProjectManager.Authentication.Configuration
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentityConfiguration (this IServiceCollection services, IConfiguration config)
        {
            //IDENTITY EF SETTINGS
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );

            services.AddDefaultIdentity<ApplicationUser>(opts => 
                {
                    opts.Password.RequiredLength = 8;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireDigit = false;
                }            
            ).AddRoles<IdentityRole>()
             .AddErrorDescriber<PortugueseIdentityMessages>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

            //JWT SETTINGS
            var appSettingsSection = config.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOpts =>
            {
                bearerOpts.RequireHttpsMetadata = true;
                bearerOpts.SaveToken = true;

                bearerOpts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = appSettings.ValidIn,
                    ValidIssuer = appSettings.Emitter
                };
            });

            return services;
        }

        public static IApplicationBuilder UseIdentityConfiguration (this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }
    }
}

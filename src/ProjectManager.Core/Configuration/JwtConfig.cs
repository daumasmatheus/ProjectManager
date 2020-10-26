using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProjectManager.Core.Configuration
{
    public static class JwtConfig
    {
        public static void AddJwtConfiguration (this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opts =>
            {
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = appSettings.Emitter,
                    ValidAudience = appSettings.ValidIn,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });
        }

        public static void AddPolicyConfiguration (this IServiceCollection services)
        {
            services.AddAuthorization(opts =>
            {
                opts.AddPolicy("AllowRead", pol =>
                {
                    pol.RequireRole(new string[] { "Allow Read" });
                });
            });
        }

        public static void UseAuthConfiguration (this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}

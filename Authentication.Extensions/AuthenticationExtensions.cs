using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Authentication.Extensions;

public static class AuthenticationExtensions
{
    /// <summary>
    /// Registers the authentication services common to the organization.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddStandardAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("Authentication:Jwt");
        services.AddAuthentication()
        .AddJwtBearer(jwtOptions =>
        {
            jwtOptions.RequireHttpsMetadata = jwtSettings.GetValue<bool>("RequireHttps");
            jwtOptions.Authority = jwtSettings.GetValue<string>("Authority");
            jwtOptions.Audience = jwtSettings.GetValue<string>("Audience");
            jwtOptions.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
            {
                OnTokenValidated = context =>
                {
                    return Task.CompletedTask;
                }
            };
        });
    }
}

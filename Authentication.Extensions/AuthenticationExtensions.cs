using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Jwt
{
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
                jwtOptions.Authority = jwtSettings.GetValue<string>("Authority");
                jwtOptions.Audience = jwtSettings.GetValue<string>("Audience");
            });
        }
    }
}

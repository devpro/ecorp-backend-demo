using Microsoft.Extensions.DependencyInjection;

namespace Ecorp.BackendDemo.Common.AspNetCore.DependencyInjection
{
    public static class CorsServiceCollectionExtensions
    {
        public static IServiceCollection AddCors(this IServiceCollection services, string policyName, List<string> allowedOrigins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    policyName,
                    builder =>
                    {
                        builder
                            .WithOrigins(allowedOrigins.ToArray())
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            return services;
        }
    }
}

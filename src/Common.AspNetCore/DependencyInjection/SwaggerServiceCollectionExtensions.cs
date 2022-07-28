using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Ecorp.BackendDemo.Common.AspNetCore.DependencyInjection
{
    public static class SwaggerServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, OpenApiInfo openApi)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(openApi.Version, openApi);
            });

            return services;
        }
    }
}

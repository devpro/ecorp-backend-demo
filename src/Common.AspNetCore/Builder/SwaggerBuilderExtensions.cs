using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace Ecorp.BackendDemo.Common.AspNetCore.Builder
{
    public static class SwaggerBuilderExtensions
    {
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, OpenApiInfo openApi, bool isSwaggerEnabled)
        {
            if (isSwaggerEnabled)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint($"/swagger/{openApi.Version}/swagger.json",
                    $"{openApi.Title} {openApi.Version}"));
            }

            return app;
        }
    }
}

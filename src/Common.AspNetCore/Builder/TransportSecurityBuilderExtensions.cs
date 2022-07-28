using Microsoft.AspNetCore.Builder;

namespace Ecorp.BackendDemo.Common.AspNetCore.Builder
{
    public static class TransportSecurityBuilderExtensions
    {
        public static IApplicationBuilder UseHttps(this IApplicationBuilder app, bool isHttpsRedirectionEnabled)
        {
            if (isHttpsRedirectionEnabled)
            {
                app.UseHttpsRedirection();
                app.UseHsts();
            }

            return app;
        }
    }
}

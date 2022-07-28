using Microsoft.OpenApi.Models;

namespace Ecorp.BackendDemo.WebApi
{
    public class ApplicationConfiguration : Withywoods.Configuration.ConfigurationBase
    {
        public ApplicationConfiguration(IConfigurationRoot configurationRoot)
            : base(configurationRoot)
        {
        }

        // flags

        public bool IsOpenTelemetryEnabled => TryGetSection("Application:IsOpenTelemetryEnabled").Get<bool>();

        public bool IsHttpsRedirectionEnabled => TryGetSection("Application:IsHttpsRedirectionEnabled").Get<bool>();

        public bool IsSwaggerEnabled => TryGetSection("Application:IsSwaggerEnabled").Get<bool>();

        // definitions

        public string CorsPolicyName => "RestrictedOrigins";

        public string HealthCheckEndpoint => "/health";

        public OpenApiInfo OpenApi => TryGetSection("OpenApi").Get<OpenApiInfo>();

        public string OpenTelemetryService => TryGetSection("OpenTelemetry:ServiceName").Get<string>();

        // infrastructure

        public List<string> CorsAllowedOrigin => TryGetSection("AllowedOrigins").Get<List<string>>();

        public string OpenTelemetryCollectorEndpoint => TryGetSection("OpenTelemetry:CollectorEndpoint").Get<string>();
    }
}

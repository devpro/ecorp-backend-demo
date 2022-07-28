using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Ecorp.BackendDemo.Common.AspNetCore.DependencyInjection
{
    public static class OpenTelemetryServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenTelemetry(this IServiceCollection services, bool isOpenTelemetryEnabled, string openTelemetryCollectorEndpoint,
            ILoggingBuilder logging, string serviceName, Action<Activity, string, object>? enrichAction = default)
        {
            if (!isOpenTelemetryEnabled)
            {
                return services;
            }

            if (logging == null)
            {
                throw new ArgumentNullException(nameof(logging));
            }

            // logs
            logging.AddOpenTelemetry(builder =>
            {
                builder.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName));
                builder.IncludeFormattedMessage = true;
                builder.IncludeScopes = true;
                builder.ParseStateValues = true;
                builder.AddOtlpExporter(options => options.Endpoint = new Uri(openTelemetryCollectorEndpoint));
            });

            // traces
            services.AddOpenTelemetryTracing(builder =>
            {
                builder.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName));
                builder.AddAspNetCoreInstrumentation(options =>
                {
                    options.Filter = (httpContext) =>
                    {
                        var pathsToIgnore = "/health,/favicon.ico";

                        foreach (var path in pathsToIgnore.Split(','))
                        {
                            if (httpContext.Request.Path.StartsWithSegments(path))
                            {
                                return false;
                            }
                        }

                        return true;
                    };

                    options.RecordException = true;
                    if (enrichAction != default)
                    {
                        options.Enrich = enrichAction;
                    }
                });
                builder.AddHttpClientInstrumentation();
                // no added traces source for the moment: "builder.AddSource(openTelemetryTracingSource);"
                builder.AddOtlpExporter(options => options.Endpoint = new Uri(openTelemetryCollectorEndpoint));
            });

            // metrics
            services.AddOpenTelemetryMetrics(builder =>
            {
                builder.SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName));
                builder.AddAspNetCoreInstrumentation();
                builder.AddHttpClientInstrumentation();
                // no added metrics for the moment: "builder.AddMeter(...);"
                builder.AddOtlpExporter(options => options.Endpoint = new Uri(openTelemetryCollectorEndpoint));
            });

            return services;
        }
    }
}

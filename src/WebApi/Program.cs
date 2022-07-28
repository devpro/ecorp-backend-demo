// creates the builder and gets the configuration
var builder = WebApplication.CreateBuilder(args);
var configuration = new ApplicationConfiguration(builder.Configuration);

// adds services to the container
builder.Services.AddCors(configuration.CorsPolicyName, configuration.CorsAllowedOrigin);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger(configuration.OpenApi);
builder.Services.AddHealthChecks();
builder.Services.AddOpenTelemetry(configuration.IsOpenTelemetryEnabled, configuration.OpenTelemetryCollectorEndpoint, builder.Logging, configuration.OpenTelemetryService);

// creates the app and configures the HTTP request pipeline
var app = builder.Build();
app.UseDeveloperExceptionPage(app.Environment);
app.UseSwagger(configuration.OpenApi, configuration.IsSwaggerEnabled);
app.UseHttps(configuration.IsHttpsRedirectionEnabled);
app.UseCors(configuration.CorsPolicyName);
app.MapControllers().RequireCors(configuration.CorsPolicyName);
app.MapHealthChecks(configuration.HealthCheckEndpoint);

// runs the app
app.Run();

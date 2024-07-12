using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Configure Cors
builder.Services.AddCors(options =>
{
    var clientAppUrl = builder.Configuration.GetValue<string>("ClientAppUrl");
    var GestionPatientsApiUrl = builder.Configuration.GetValue<string>("GestionPatientsApiUrl");
    var GestionNotesApiUrl = builder.Configuration.GetValue<string>("GestionNotesApiUrl");
    var RapportDiabeteApiUrl = builder.Configuration.GetValue<string>("RapportDiabeteApiUrl");
    options.AddPolicy("CorsPolicy",
        policy =>
        {
            if (!string.IsNullOrEmpty(clientAppUrl))
            {
                policy.WithOrigins(clientAppUrl);
            }
            if (!string.IsNullOrEmpty(GestionPatientsApiUrl))
            {
                policy.WithOrigins(GestionPatientsApiUrl);
            }
            if (!string.IsNullOrEmpty(GestionNotesApiUrl))
            {
                policy.WithOrigins(GestionNotesApiUrl);
            }
            if (!string.IsNullOrEmpty(RapportDiabeteApiUrl))
            {
                policy.WithOrigins(RapportDiabeteApiUrl);
            }
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
            policy.AllowCredentials();
        });
});

// Configure health checks
builder.Services
    .AddHealthChecks()
    .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

// Add Ocelot
builder.Services.AddOcelot(builder.Configuration);

// Add Ocelot json file configuration
builder.Configuration.AddJsonFile("ocelot.json");

WebApplication app = builder.Build();

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseEndpoints(_ => { });

// Map health check endpoints
app.MapHealthChecks("/hc", new HealthCheckOptions()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
});

app.MapHealthChecks("/liveness", new HealthCheckOptions
{
    Predicate = r => r.Name.Contains("self")
});

await app.UseOcelot();
await app.RunAsync();
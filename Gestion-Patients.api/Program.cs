using Gestion_Patients.api.Data;
using Gestion_Patients.api.Repositories;
using Gestion_Patients.api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PatientContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Gestion-Patients.db")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<PatientContext>()
        .AddDefaultTokenProviders();

var jwt = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwt["SecretKey"]!);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
        };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("organizer", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("organizer");
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
    })
    .AddPolicy("practitioner", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("practitioner");
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
    })
    .AddPolicy("organizerOrPractitioner", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireAssertion(context =>
            context.User.IsInRole("organizer") || context.User.IsInRole("practitioner"));
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
    });

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<PatientContext>();
    var authService = scope.ServiceProvider.GetService<IAuthenticationService>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var succeed = dbcontext.Database.EnsureCreated();
    if (succeed)
    {
        var seeder = new DatabaseSeeder(userManager, roleManager);
        await seeder.EnsureOrganizerIsCreated();
        await seeder.EnsurePractitionerIsCreated();
        await seeder.EnsureAdminIsCreated();
    }
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();

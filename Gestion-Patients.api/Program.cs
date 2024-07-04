using Gestion_Patients.api.Data;
using Gestion_Patients.api.Repositories;
using Gestion_Patients.api.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PatientContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Gestion-Patients.db")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<PatientContext>()
        .AddDefaultTokenProviders();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
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

    dbcontext.Database.EnsureCreated();
    var result = await authService!.EnsureAdminCreated();
    Console.WriteLine(result);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();

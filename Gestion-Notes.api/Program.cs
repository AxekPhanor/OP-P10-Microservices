using Gestion_Notes.api.Data;
using Gestion_Notes.api.Repositories;
using Gestion_Notes.api.Services;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();

var mongoDb = builder.Configuration.GetSection("MongoDb");

var mongoClient = new MongoClient(mongoDb["ConnectionString"]);
var dbContextOptions =
    new DbContextOptionsBuilder<MongoDbContext>().UseMongoDB(mongoClient, mongoDb["DatabaseName"]!);
var db = new MongoDbContext(dbContextOptions.Options);
builder.Services.AddSingleton(db);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

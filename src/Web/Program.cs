using Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Application.Services;
using Application.Interfaces;
using Application.Profiles;
using Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the SQLite connection
var connection = new SqliteConnection("Data Source=Proyecto-Web-Api.db");
connection.Open();

// Set journal mode to DELETE using PRAGMA statement
using (var command = connection.CreateCommand())
{
    command.CommandText = "PRAGMA journal_mode = DELETE";
    command.ExecuteNonQuery();
}

builder.Services.AddDbContext<ApplicationContext>(dbContextOptions => dbContextOptions.UseSqlite(connection));

// Repository
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ITallerRepository, TallerRepository>();
builder.Services.AddScoped<IBicicletaRepository, BicicletaRepository>();
// Registra un repositorio base genérico para las entidades,
// permitiendo que se realicen operaciones comunes de acceso a datos.
builder.Services.AddScoped<IBaseRepository<Cliente>, BaseRepository<Cliente>>();
builder.Services.AddScoped<IBaseRepository<Taller>, BaseRepository<Taller>>();
builder.Services.AddScoped<IBaseRepository<Bicicleta>, BaseRepository<Bicicleta>>();

// Service
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ITallerService, TallerService>();
builder.Services.AddScoped<IBicicletaService, BicicletaService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); //AutoMapper

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

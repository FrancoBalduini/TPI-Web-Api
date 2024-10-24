using Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Application.Services;
using Domain.Interfaces;
using Application.Profiles;
using Domain.Entities;
using Application.Interfaces;
using Domain.Enums;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Infrastructure.Service;


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
builder.Services.AddScoped<IDuenoRepository, DuenoRepository>();
builder.Services.AddScoped<IMantenimientoRepository, MantenimientoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Registra un repositorio base genérico para las entidades,
// permitiendo que se realicen operaciones comunes de acceso a datos.
builder.Services.AddScoped<IBaseRepository<Cliente>, BaseRepository<Cliente>>();
builder.Services.AddScoped<IBaseRepository<Taller>, BaseRepository<Taller>>();
builder.Services.AddScoped<IBaseRepository<Bicicleta>, BaseRepository<Bicicleta>>();
builder.Services.AddScoped<IBaseRepository<Dueno>, BaseRepository<Dueno>>();
builder.Services.AddScoped<IBaseRepository<Mantenimiento>, BaseRepository<Mantenimiento>>();
builder.Services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();

// Service
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ITallerService, TallerService>();
builder.Services.AddScoped<IBicicletaService, BicicletaService>();
builder.Services.AddScoped<IDuenoService, DuenoService>();
builder.Services.AddScoped<IMantenimientoService, MantenimientoService>();  
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();


builder.Services.AddAutoMapper(typeof(AutoMapperProfile)); //AutoMapper

#region Authentication
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("ApiBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Introduzca el token JWT como: Bearer {token}"
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiBearerAuth"
                }
            },
            new List<string>()
        }
    });
});
//configurar las opciones para la clase AutenticacionServiceOptions
builder.Services.Configure<AuthenticationService.AutenticacionServiceOptions>(
    builder.Configuration.GetSection("Authentication"));

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    });



// configuración de autorización basada en roles
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Cliente", policy => policy.RequireRole(UserRole.Cliente.ToString(), UserRole.SysAdmin.ToString()));
    options.AddPolicy("Dueno", policy => policy.RequireRole(UserRole.Dueno.ToString(), UserRole.SysAdmin.ToString()));
    options.AddPolicy("SysAdmin", policy => policy.RequireRole(UserRole.SysAdmin.ToString()));


});
#endregion

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

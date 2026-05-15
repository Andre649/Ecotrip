using Npgsql;
using System.Data;
using EcoTrip.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Forçar a porta 5261
builder.WebHost.UseUrls("http://0.0.0.0:5261");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção do Banco
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(connectionString));
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();

var app = builder.Build();

// ATENÇÃO: Swagger fora do IF para garantir que funcione no Codespaces
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "EcoTrip API v1");
    c.RoutePrefix = string.Empty; // Define o Swagger como página inicial (/)
});

app.UseAuthorization();
app.MapControllers();

app.Run();

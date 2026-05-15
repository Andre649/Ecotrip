using Npgsql;
using System.Data;
using EcoTrip.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a Controllers e Swagger (Configuração Simplificada)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Sem parâmetros customizados para evitar erro de namespace por enquanto

// 1. Configuração da Conexão com o Banco
builder.Services.AddScoped<IDbConnection>(sp => 
    new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Registro do Repositório
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // O padrão já resolve para /swagger/index.html
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

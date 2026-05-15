using Dapper;
using EcoTrip.API.Models;
using System.Data;

namespace EcoTrip.API.Repositories;

public class VeiculoRepository : IVeiculoRepository
{
    private readonly IDbConnection _dbConnection;

    public VeiculoRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<Guid> AddAsync(Veiculo veiculo)
    {
        var sql = @"
            INSERT INTO public.veiculos 
            (usuario_id, marca, modelo, ano, consumo_medio_cidade, consumo_medio_rodovia, tipo_combustivel_padrao)
            VALUES (@UsuarioId, @Marca, @Modelo, @Ano, @ConsumoMedioCidade, @ConsumoMedioRodovia, @TipoCombustivelPadrao)
            RETURNING id";
        
        return await _dbConnection.ExecuteScalarAsync<Guid>(sql, veiculo);
    }
}

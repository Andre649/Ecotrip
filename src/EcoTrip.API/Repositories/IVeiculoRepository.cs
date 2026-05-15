using EcoTrip.API.Models;

namespace EcoTrip.API.Repositories;

public interface IVeiculoRepository
{
    Task<Guid> AddAsync(Veiculo veiculo);
}

using EcoTrip.API.Models;
using EcoTrip.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EcoTrip.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VeiculosController : ControllerBase
{
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculosController(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Veiculo veiculo)
    {
        try
        {
            // Em uma fase futura, o usuario_id virá do Token JWT (Auth)
            // Por enquanto, garantimos que ele não seja nulo para o teste
            if (veiculo.UsuarioId == Guid.Empty)
                return BadRequest("O ID do usuário é obrigatório.");

            var idCriado = await _veiculoRepository.AddAsync(veiculo);
            veiculo.Id = idCriado;

            return CreatedAtAction(nameof(Create), new { id = idCriado }, veiculo);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }
}

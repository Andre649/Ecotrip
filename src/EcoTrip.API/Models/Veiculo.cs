using System;

namespace EcoTrip.API.Models;

public class Veiculo
{
    public Guid Id { get; set; }
    public Guid UsuarioId { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Ano { get; set; }
    public decimal ConsumoMedioCidade { get; set; }
    public decimal ConsumoMedioRodovia { get; set; }
    public string TipoCombustivelPadrao { get; set; } = string.Empty;
}

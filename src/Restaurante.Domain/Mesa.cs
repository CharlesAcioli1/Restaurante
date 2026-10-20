using Restaurante.Domain.Enums;

namespace Restaurante.Domain;

public sealed class Mesa
{
    public int Id { get; set; }
    public int StatusMesaId { get; set; }
    public int RestauranteId { get; set; }
    public string Numero { get; set; } = default!;

    public Restaurante? Restaurante { get; set; }
    public StatusMesa? StatusMesa { get; set; }
}
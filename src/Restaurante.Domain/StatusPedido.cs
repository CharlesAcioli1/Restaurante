using Restaurante.Domain.Enums;

namespace Restaurante.Domain;

public class StatusPedido
{
    public int Id { get; set; }
    public StatusPedidoEnum Status { get; set; }
    public DateTime DataHora { get; set; } = DateTime.UtcNow;
}
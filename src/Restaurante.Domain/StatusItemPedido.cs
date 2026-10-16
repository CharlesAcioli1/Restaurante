using Restaurante.Domain.Enums;

namespace Restaurante.Domain;

public class StatusItemPedido
{   
    public int Id { get; set; }
    public StatusItemPedidoEnum Status { get; set; }
    public DateTime DataHora { get; set; } = DateTime.UtcNow;
}
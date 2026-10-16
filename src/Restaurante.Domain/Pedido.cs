namespace Restaurante.Domain;

public sealed class Pedido
{
    public int Id { get; set; }
    public int IdMesa { get; set; }
    public int StatusId { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public Mesa? Mesa { get; set; }
    public StatusPedido? Status { get; set; }
}
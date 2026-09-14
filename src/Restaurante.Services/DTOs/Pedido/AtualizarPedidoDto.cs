using Dom = Restaurante.Domain;
namespace Restaurante.Services.DTOs.Pedido;

public sealed record AtualizarPedidoDto
{
    public int Id { get; init; }
    public int IdMesa { get; init; }
    public int StatusId { get; init; }
    public DateTime DataCriacao { get; init; }
}
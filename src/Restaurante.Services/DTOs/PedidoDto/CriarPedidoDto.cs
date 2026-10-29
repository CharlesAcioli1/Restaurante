namespace Restaurante.Services.DTOs.PedidoDto;

public sealed record CriarPedidoDto
{
    public int IdMesa { get; init; }
    public int StatusId { get; init; }
    public DateTime DataCriacao { get; init; }
}
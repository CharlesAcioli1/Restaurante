namespace Restaurante.Services.DTOs.ItemPedidoDto;

public sealed record CriarItemPedidoDto
{
    public int PedidoId { get; init; }
    public int ItemCardapioId { get; init; }
    public int Quantidade { get; init; }
    public string? Observacao { get; init; }
}

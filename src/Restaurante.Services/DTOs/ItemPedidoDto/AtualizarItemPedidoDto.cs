namespace Restaurante.Services.DTOs.ItemPedidoDto;

public sealed record AtualizarItemPedidoDto
{
    public int PedidoId { get; init; }
    public int ItemId { get; init; }
    public int StatusId { get; init; }
    public int Quantidade { get; init; }
    public string? Observacao { get; init; }
}

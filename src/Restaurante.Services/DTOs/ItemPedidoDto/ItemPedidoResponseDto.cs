using Restaurante.Domain;

namespace Restaurante.Services.DTOs.ItemPedidoDto;

public sealed record ItemPedidoResponseDto
{
    public int PedidoId { get; init; }
    public int ItemId { get; init; }
    public int StatusId { get; init; }
    public string? NomeItem { get; init; }
    public int Quantidade { get; init; }
    public string? Observacao { get; init; }
    public decimal PrecoUnitario { get; init; }
    public decimal Subtotal => Quantidade * PrecoUnitario;


    public static ItemPedidoResponseDto ItemPedidoToDto(ItemPedido itemPedido)
        => new()
        {
            PedidoId = itemPedido.PedidoId,
            ItemId = itemPedido.ItemId,
            StatusId = itemPedido.StatusId,
            NomeItem = itemPedido.Item?.Nome,
            PrecoUnitario = itemPedido.PrecoUnitario,
            Quantidade = itemPedido.Quantidade,
            Observacao = itemPedido.Observacao,

        };
}

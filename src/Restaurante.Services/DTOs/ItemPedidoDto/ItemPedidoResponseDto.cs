using Restaurante.Domain;

namespace Restaurante.Services.DTOs.ItemPedidoDto;

public class ItemPedidoResponseDto
{
    public int PedidoId { get; init; }
    public int ItemId { get; init; }
    public int StatusId { get; init; }
    public int Quantidade { get; init; }
    public string? Descricao { get; init; }

    public static ItemPedidoResponseDto ItemPedidoToDto(ItemPedido itemPedido)
        => new()
        {
            PedidoId = itemPedido.PedidoId,
            ItemId = itemPedido.ItemId,
            StatusId = itemPedido.StatusId,
            Quantidade = itemPedido.Quantidade,
            Descricao = itemPedido.Descricao
        };
}

using Restaurante.Domain;
using Restaurante.Services.DTOs.ItemPedidoDto;
namespace Restaurante.Services.DTOs.PedidoDto;

public sealed record PedidoResponseDto
{
    public int Id { get; init; }
    public int IdMesa { get; init; }
    public int? StatusId { get; init; }
    public DateTime DataCriacao { get; init; }

    public List<ItemPedidoResponseDto> Itens { get; init; } = [];

    public static PedidoResponseDto PedidoToDto(Pedido pedido)
        => new()
        {
            Id = pedido.Id,
            IdMesa = pedido.IdMesa,
            StatusId = pedido.StatusId,
            DataCriacao = pedido.DataCriacao,
            Itens = [.. pedido.Itens.Select(ItemPedidoResponseDto.ItemPedidoToDto)]
        };
}
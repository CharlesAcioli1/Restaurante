using Restaurante.Domain;

namespace Restaurante.Services.DTOs.ItemPedidoDto;

public sealed record ItemPedidoResponseDto
{
    public int ItemCardapioId { get; init; }
    public string? NomeItem { get; init; }
    public int Quantidade { get; init; }
    public string? Observacao { get; init; }
    public decimal PrecoUnitario { get; init; }
    public decimal Subtotal => Quantidade * PrecoUnitario;


    public static ItemPedidoResponseDto ItemPedidoToDto(ItemPedido itemPedido)
        => new()
        {
            ItemCardapioId = itemPedido.ItemCardapioId,
            NomeItem = itemPedido.ItemCardapio?.Item?.Nome,
            PrecoUnitario = itemPedido.PrecoUnitario,
            Quantidade = itemPedido.Quantidade,
            Observacao = itemPedido.Observacao
        };
}

namespace Restaurante.Domain;

public sealed class ItemPedido
{
    public int PedidoId { get; set; }
    public int ItemId { get; set; }
    public int ItemCardapioId { get; set; }
    public int StatusId { get; set; }
    public int Quantidade { get; set; } = 1;
    public string? Observacao { get; set; }
    public decimal PrecoUnitario { get; set; }

    public Pedido? Pedido { get; set; }
    public Item? Item { get; set; }
    public ItemCardapio? ItemCardapio { get; set; }
    public StatusItemPedido? Status { get; set; }
}
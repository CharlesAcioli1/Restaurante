namespace Restaurante.Domain;

public sealed class ItemPedido
{
    public int PedidoId { get; set; }
    public int ItemId { get; set; }
    public int StatusId { get; set; }
    public int Quantidade { get; set; }
    public string? Descricao { get; set; }

    public Pedido? Pedido { get; set; }
    public Item? Item { get; set; }
    public StatusItemPedido? Status { get; set; }
}
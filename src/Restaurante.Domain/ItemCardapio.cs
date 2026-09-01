namespace Restaurante.Domain;

public sealed class ItemCardapio
{
    public int CardapioId { get; set; }
    public int ItemId { get; set; }
    public decimal Preco { get; set; }

    public Cardapio? Cardapio { get; set; }
    public Item? Item { get; set; }
}
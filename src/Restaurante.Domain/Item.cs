namespace Restaurante.Domain;

public sealed class Item
{
    public int Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Descricao { get; set; } = default!;

    public int CardapioId { get; set; }
    public Cardapio? Cardapio { get; set; }

    public int? CozinhaId { get; set; }
    public Cozinha? Cozinha { get; set; }
}
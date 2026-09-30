namespace Restaurante.Domain;

public sealed class Cardapio
{
    public int Id { get; set; }
    public string Nome { get; set; } = default!;
    public int RestauranteId { get; set; }

    public Restaurante? Restaurante { get; set; }
}
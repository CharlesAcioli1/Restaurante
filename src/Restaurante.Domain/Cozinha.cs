namespace Restaurante.Domain;

public sealed class Cozinha
{
    public int Id { get; set; }
    public int RestauranteId { get; set; }
    public string Nome { get; set; } = default!;

    public Restaurante? Restaurante { get; set; }
    public ICollection<StatusCozinha> StatusCozinha { get; set; } = [];
}
namespace Restaurante.Domain;

public sealed class Cozinha
{
    public int Id { get; set; }
    public int RestauranteId { get; set; }
    public int StatusId { get; set; }
    public string Nome { get; set; } = string.Empty;

    public Restaurante? Restaurante { get; set; }
    public StatusCozinha? StatusCozinha { get; set; }
}
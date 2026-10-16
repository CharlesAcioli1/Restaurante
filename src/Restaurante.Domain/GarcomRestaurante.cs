namespace Restaurante.Domain;

public sealed class GarcomRestaurante
{
    public int GarcomId { get; set; }
    public int RestauranteId { get; set; }
    public DateTime DataInicio { get; set; } = DateTime.UtcNow;

    public Restaurante? Restaurante { get; set; }
    public Garcom? Garcom { get; set; }
}
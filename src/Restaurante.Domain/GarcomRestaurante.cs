namespace Restaurante.Domain;

public sealed class GarcomRestaurante
{
    public int GarcomId { get; set; }
    public int RestauranteId { get; set; }
    public int StatusId { get; set; }
    public DateTime DataInicio { get; set; } = DateTime.UtcNow;

    public StatusGarcom? Status { get; set; }
    public Restaurante? Restaurante { get; set; }
    public Garcom? Garcom { get; set; }
}
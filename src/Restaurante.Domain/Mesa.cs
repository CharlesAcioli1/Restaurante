namespace Restaurante.Domain;

public sealed class Mesa
{
    public int Id { get; set; }
    public int StatusId { get; set; }
    public int RestauranteId { get; set; }
    public int Numero { get; set; }

    public StatusMesa? Status { get; set; }
    public Restaurante? Restaurante { get; set; }
}
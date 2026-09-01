namespace Restaurante.Domain;

public sealed class GarcomMesa
{
    public int GarcomId { get; set; }
    public int MesaId { get; set; }

    public Garcom? Garcom { get; set; }
    public Mesa? Mesa { get; set; }
}
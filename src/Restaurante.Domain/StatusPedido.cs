namespace Restaurante.Domain;

public class StatusPedido
{
    public int Id { get; set; }
    public string Descricao { get; set; } = default!;
    public DateTime DataHora { get; set; } = DateTime.UtcNow;
}
namespace Restaurante.Domain;

public class StatusPedido
{
    //Pendente = 1,
    //EmPreparo = 2,
    //Entregue = 3,
    //Cancelado = 4

    public int Id { get; set; }
    public string Descricao { get; set; } = default!;
    public DateTime DataHora { get; set; } = DateTime.UtcNow;
}
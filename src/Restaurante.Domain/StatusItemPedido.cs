namespace Restaurante.Domain;

public class StatusItemPedido
{
    //Solicitado = 1,
    //EmPreparo = 2,
    //Pronto = 3,
    //Entregue = 4,
    //Cancelado = 5

    public int Id { get; set; }
    public string Descricao { get; set; } = default!;
    public DateTime DataHora { get; set; } = DateTime.UtcNow;
}
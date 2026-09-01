namespace Restaurante.Domain;

public sealed class FilaPedido
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    //public int Posicao { get; set; }
    public string Prioridade { get; set; } = string.Empty;
    public DateTime DataHoraEntrada { get; set; } = DateTime.UtcNow;

    public Pedido? Pedido { get; set; }
}
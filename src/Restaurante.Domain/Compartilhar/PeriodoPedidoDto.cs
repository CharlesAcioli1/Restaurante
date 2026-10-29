namespace Restaurante.Domain.Compartilhar;

public sealed record PeriodoPedidoDto
{
    public DateTime PedidoInicio { get; init; }
    public DateTime PedidoFim {  get; init; }

    public PeriodoPedidoDto(DateTime dateUtc)
    {
        PedidoInicio = dateUtc.Date;
        PedidoFim = dateUtc.AddDays(1).AddTicks(-1);
    }
}
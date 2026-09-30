using Dom = Restaurante.Domain;

namespace Restaurante.Services.DTOs.FilaPedido;

public sealed record FilaPedidoResponseDto
{
    public int Id { get; init; }
    public int PedidoId { get; init; }
    public DateTime DataHoraEntrada { get; init; }

    public static FilaPedidoResponseDto FilaPedidoToDo(Dom.FilaPedido filaPedido)
        => new()
        {
            Id = filaPedido.Id,
            PedidoId = filaPedido.PedidoId,
            DataHoraEntrada = filaPedido.DataHoraEntrada
        };
}

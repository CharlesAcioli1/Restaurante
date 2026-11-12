using Restaurante.Domain;
using Restaurante.Domain.Enums;
using Restaurante.Services.DTOs.ItemPedidoDto;
namespace Restaurante.Services.DTOs.PedidoDto;

public sealed record PedidoResponseDto
{
    public int Id { get; init; }
    public int IdMesa { get; init; }
    public string NumeroMesa { get; init; } = default!;
    public string NomeRestaurante { get; init; } = default!;
    public string StatusId { get; init; } = default!;
    public DateTime DataCriacao { get; init; }

    public static PedidoResponseDto PedidoToDto(Pedido pedido)
    {
        string nomeStatus = Enum.IsDefined(typeof(StatusPedidoEnum), pedido.StatusId)
            ? ((StatusPedidoEnum)pedido.StatusId).ToString()
            : "Valor incorreto";
        return new()
           {
               Id = pedido.Id,
               IdMesa = pedido.IdMesa,
               NumeroMesa = pedido.Mesa?.Numero ?? "Mesa não encontrada!",
               NomeRestaurante = pedido.Mesa?.Restaurante?.Nome ?? "Restaurante não encontrado!",
               StatusId = nomeStatus,
               DataCriacao = pedido.DataCriacao
           };
    }
}
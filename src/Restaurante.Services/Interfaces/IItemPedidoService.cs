using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.ItemPedidoDto;

namespace Restaurante.Services.Interfaces
{
    public interface IItemPedidoService
    {
        Task<Resultado> ObterPorIdAsync(int pedidoId, int itemId, int statusId);

        Task<Resultado> CriarAsync(ItemPedido itemPedido);
        Task<Resultado> AtualizarAsync(ItemPedido itemPedido);
        Task<Resultado> DeletarAsync(ItemPedido itemPedido);
    }
}

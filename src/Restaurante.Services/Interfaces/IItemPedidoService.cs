using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.ItemPedidoDto;

namespace Restaurante.Services.Interfaces
{
    public interface IItemPedidoService
    {
        Task<Resultado> ObterPorPedidoIdAsync(int id);
        Task<Resultado> ObterPorItemIdAsync(int id);
        Task<Resultado> ObterPorStatusId(int id);

        Task<Resultado> CriarAsync(ItemPedido itemPedido);
        Task<Resultado> AtualizarAsync(ItemPedido itemPedido);
        Task<Resultado> DeletarAsync(ItemPedido itemPedido);
    }
}

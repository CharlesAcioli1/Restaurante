using Dom = Restaurante.Domain;

using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IItemPedidoRepository
    {
        Task<Resultado> ObterPorIdAsync(int pedidoId, int itemId, int statusId);

        Task<Resultado> ObterTodosAsync();
        Task<Resultado> CriarAsync(Dom.ItemPedido itemPedido);
        Task<Resultado> AtualizarAsync(Dom.ItemPedido itemPedido);
        Task<Resultado> DeletarAsync(Dom.ItemPedido itemPedido);
    }
}
using Dom = Restaurante.Domain;

using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IItemPedidoRepository
    {
        Task<Resultado> ObterPorPedidoIdAsync(int id);
        Task<Resultado> ObterPorItemIdAsync(int id);
        Task<Resultado> ObterPorStatusId(int id);

        Task<Resultado> CriarAsync(Dom.ItemPedido itemPedido);
        Task<Resultado> AtualizarAsync(Dom.ItemPedido itemPedido);
        Task<Resultado> DeletarAsync(Dom.ItemPedido itemPedido);
    }
}
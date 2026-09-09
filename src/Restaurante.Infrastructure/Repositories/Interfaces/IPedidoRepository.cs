using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    internal interface IPedidoRepository
    {
        Task<Resultado> ObterTodasAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterPorMesaIdAsync(int mesaId);
        Task<Resultado> ObterPorStatusIdAsync(int statusId);
        Task<Resultado> ObterPorDataAsync(DateTime dataUtc);
        Task<Resultado> CriarAsync(Dom.Pedido pedido);
        Task<Resultado> AtualizarAsync(Dom.Pedido pedido);
        Task<Resultado> DeletarAsync(Dom.Pedido pedido);
    }
}
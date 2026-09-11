using Restaurante.Domain.Compartilhar;
using Dom = Restaurante.Domain;
namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IPedidoRepository
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
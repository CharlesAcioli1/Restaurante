using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IFilaPedidoRepository
    {
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterPorPedidoId(int id);
        Task<Resultado> ObterPorData(DateTime dateUtc);
        Task<Resultado> ObterTodosAsync();
    }
}
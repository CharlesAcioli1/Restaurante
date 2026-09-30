using Restaurante.Domain.Compartilhar;

namespace Restaurante.Services.Interfaces
{
    public interface IFilaPedidoService
    {
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterPorPedidoId(int id);
        Task<Resultado> ObterPorData(DateTime dateUtc);
    }
}
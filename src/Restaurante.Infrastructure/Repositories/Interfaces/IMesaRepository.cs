using Restaurante.Domain.Compartilhar;
using Dom = Restaurante.Domain;
namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IMesaRepository
    {
        Task<Resultado> ObterTodasAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId);
        Task<Resultado> CriarAsync(Dom.Mesa mesa);
        Task<Resultado> AtualizarAsync(Dom.Mesa mesa);
        Task<Resultado> DeletarAsync(Dom.Mesa mesa);
    }
}
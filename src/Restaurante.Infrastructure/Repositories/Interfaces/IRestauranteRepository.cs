using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IRestauranteRepository
    {
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> CriarAsync(Dom.Restaurante restaurante);
        Task<Resultado> AtualizarAsync(Dom.Restaurante restaurante);
        Task<Resultado> DeletarAsync(Dom.Restaurante restaurante);
    }
}

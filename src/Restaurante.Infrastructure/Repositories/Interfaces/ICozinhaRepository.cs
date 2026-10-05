using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface ICozinhaRepository
    {
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId);
        Task<Resultado> ObterStatusAtualAsync(int cozinhaId);
        Task<Resultado> CriarAsync(Cozinha cozinha);
        Task<Resultado> AtualizarAsync(Cozinha cozinha);
        Task<Resultado> DeletarAsync(Cozinha cozinha);
    }
}
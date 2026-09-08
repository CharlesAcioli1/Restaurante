using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface ICardapioRepository
    {
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId);
        Task<Resultado> CriarCardapioAsync(Dom.Cardapio cardapio);
        Task<Resultado> AtualizarCardapioAsync(Dom.Cardapio cardapio);
        Task<Resultado> DeletarAsync(Dom.Cardapio cardapio);
    }
}

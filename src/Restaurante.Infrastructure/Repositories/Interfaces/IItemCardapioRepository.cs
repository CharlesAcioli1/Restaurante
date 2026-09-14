using Restaurante.Domain.Compartilhar;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IItemCardapioRepository
    {
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> ObterPorIdAsync(int cardpioId, int itemId);
        Task<Resultado> ObterPrecoAsync(decimal preco);
        Task<Resultado> AtualizarAsync(ItemCardapio itemCardapio);
        Task<Resultado> CriarAsync(ItemCardapio itemCardapio);
        Task<Resultado> DeletarAsync(ItemCardapio itemCardapio);
    }
}
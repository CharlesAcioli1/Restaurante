using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IItemCardapioRepository
    {
        Task<Resultado> ObterPorCardapioIdAsync(int id);
        Task<Resultado> ObterPorItemIdAsync(int id);
        Task<Resultado> ObterPrecoAsync(decimal preco);
    }
}
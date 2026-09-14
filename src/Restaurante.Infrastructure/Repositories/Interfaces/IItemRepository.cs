using Restaurante.Domain.Compartilhar;
using Dom = Restaurante.Domain;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<Resultado> ObterTodasAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterPorCozinhaId(int id);
        Task<Resultado> CriarAsync(Dom.Item item);
        Task<Resultado> AtualizarAsync(Dom.Item item);
        Task<Resultado> DeletarAsync(Dom.Item item);
    }
}
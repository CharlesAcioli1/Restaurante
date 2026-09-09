using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    internal interface IItemRepository
    {
        Task<Resultado> ObterTodasAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterPorCozinhaId(int id);
        Task<Resultado> CriarAsync(Dom.Item item);
        Task<Resultado> AtualizarAsync(Dom.Item item);
        Task<Resultado> DeletarAsync(Dom.Item item);
    }
}
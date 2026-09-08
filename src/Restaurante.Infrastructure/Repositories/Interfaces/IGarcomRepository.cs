using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IGarcomRepository
    {
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> CriarAsync(Dom.Garcom garcom);
        Task<Resultado> AtualizarAsync(Dom.Garcom garcom);
        Task<Resultado> DeletarAsync(Dom.Garcom garcom);
    }
}

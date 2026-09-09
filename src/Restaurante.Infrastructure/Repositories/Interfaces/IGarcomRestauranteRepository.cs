using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IGarcomRestauranteRepository
    {
        Task<Resultado> ObterPorGarcomId(int id);
        Task<Resultado> ObterPorRestauranteId(int id);
        Task<Resultado> ObterPorStatusId(int id);
        Task<Resultado> ObterPorData(DateTime dateUtc);
    }
}
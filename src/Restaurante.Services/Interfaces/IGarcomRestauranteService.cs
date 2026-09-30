using Restaurante.Domain.Compartilhar;

namespace Restaurante.Services.Interfaces
{
    public interface IGarcomRestauranteService
    {
        Task<Resultado> ObterPorGarcomId(int id);
        Task<Resultado> ObterPorRestauranteId(int id);
        Task<Resultado> ObterPorStatusId(int id);
        Task<Resultado> ObterPorData(DateTime dateUtc);
    }
}

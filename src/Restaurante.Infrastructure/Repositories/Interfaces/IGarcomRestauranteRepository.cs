using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IGarcomRestauranteRepository
    {
        Task<Resultado> ObterPorIdAsync(int garcomId, int restauranteId);
        Task<Resultado> CriarVinculoAsync(GarcomRestaurante garcomRestaurante);
        Task<Resultado> DeletarAsync(GarcomRestaurante garcomRestaurante);
    }
}
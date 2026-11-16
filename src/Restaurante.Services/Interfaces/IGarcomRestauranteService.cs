using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.GarcomRestauranteDto;

namespace Restaurante.Services.Interfaces
{
    public interface IGarcomRestauranteService
    {
        Task<Resultado> ObterPorIdAsync(int garcomId, int restauranteId);
        Task<Resultado> CriarVinculoAsync(CriarGarcomRestauranteDto dto);
        Task<Resultado> DeletarAsync(int garcomId, int restauranteId);
    }
}

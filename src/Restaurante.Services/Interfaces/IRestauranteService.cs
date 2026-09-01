using Restaurante.Services.DTOs.Restaurante;

namespace Restaurante.Services.Interfaces;

public interface IRestauranteService
{
    Task<IEnumerable<RestauranteResponseDto>> ObterTodosAsync();
    Task<RestauranteResponseDto?> ObterPorIdAsync(int Id);
    Task<RestauranteResponseDto> CriarAsync(CriarRestauranteDto dto);
    Task<RestauranteResponseDto?> AtualizarAsync(int Id, AtualizarRestauranteDto dto);

    Task<bool> DeletarAsync(int Id);
}
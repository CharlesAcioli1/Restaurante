using Restaurante.Services.DTOs.Cardapio;

namespace Restaurante.Services.Interfaces
{
    public interface ICardapioService
    {
        Task<IEnumerable<CardapioResponseDto>> ObterTodosAsync();
        Task<CardapioResponseDto?> ObterPorIdAsync(int id);
        Task<IEnumerable<CardapioResponseDto>> ObterPorRestauranteIdAsync(int restauranteId);
        Task<CardapioResponseDto> CriarCardapioAsync(CriarCardapioDto dto);
        Task<CardapioResponseDto?> AtualizarCardapioAsync(AtualizarCardapioDto dto);
        Task<bool> DeletarAsync(int id);
    }
}
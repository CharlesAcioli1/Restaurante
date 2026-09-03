using Restaurante.Services.DTOs;

namespace Restaurante.Services.Interfaces
{
    public interface IGarcomService
    {
        Task<IEnumerable<GarcomResponseDto>> ObterTodosAsync();
        Task<GarcomResponseDto?> ObterPorIdAsync(int id);
        Task<GarcomResponseDto> CriarAsync(CriarGarcomDto dto);
        Task<GarcomResponseDto?> AtualizarAsync(int id, AtualizarGarcomDto dto);
        Task<bool> DeletarAsync(int id);
    }
}
using Restaurante.Services.DTOs.Mesa;

namespace Restaurante.Services.Interfaces;

public interface IMesaService
{
    Task<IEnumerable<MesaResponseDto>> ObterTodasAsync();
    Task<MesaResponseDto?> ObterPorIdAsync(int id);
    Task<IEnumerable<MesaResponseDto>> ObterPorRestauranteIdAsync(int restauranteId);
    Task<MesaResponseDto> CriarAsync(CriarMesaDto dto);
    Task<bool> AtualizarAsync(AtualizarMesaDto dto);
    Task<bool> DeletarAsync(int id);
}
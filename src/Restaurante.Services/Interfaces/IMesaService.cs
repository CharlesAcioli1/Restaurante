using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.Mesa;

namespace Restaurante.Services.Interfaces;

public interface IMesaService
{
    Task<Resultado> ObterTodosAsync();
    Task<Resultado> ObterPorIdAsync(int id);
    Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId);
    Task<Resultado> CriarAsync(CriarMesaDto dto);
    Task<Resultado> AtualizarAsync(int id, AtualizarMesaDto dto);
    Task<Resultado> DeletarAsync(int id);
}
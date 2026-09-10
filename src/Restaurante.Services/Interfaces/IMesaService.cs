using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.Mesa;

namespace Restaurante.Services.Interfaces;

public interface IMesaService
{
    Task<Resultado> ObterTodosAsync();
    Task<Resultado> ObterPorIdAsync(int id);
    Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId);
    Task<Resultado> ObterPorStatusAsync(int statusId);
    Task<Resultado> CriarAsync(CriarMesaDto dto);
    Task<Resultado> AtualizarAsync(AtualizarMesaDto dto);
    Task<Resultado> DeletarAsync(int id);
}
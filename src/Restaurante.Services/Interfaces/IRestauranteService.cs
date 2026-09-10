using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.Restaurante;

namespace Restaurante.Services.Interfaces;

public interface IRestauranteService
{
    Task<Resultado> ObterTodosAsync();
    Task<Resultado> ObterPorIdAsync(int id);
    Task<Resultado> CriarAsync(CriarRestauranteDto dto);
    Task<Resultado> AtualizarAsync(AtualizarRestauranteDto dto);
    Task<Resultado> DeletarAsync(int id);
}
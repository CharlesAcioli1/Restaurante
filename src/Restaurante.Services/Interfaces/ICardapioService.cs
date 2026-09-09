using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.Cardapio;

namespace Restaurante.Services.Interfaces
{
    public interface ICardapioService
    {
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId);
        Task<Resultado> CriarCardapioAsync(CriarCardapioDto dto);
        Task<Resultado> AtualizarCardapioAsync(AtualizarCardapioDto dto);
        Task<Resultado> DeletarAsync(int id);
    }
}
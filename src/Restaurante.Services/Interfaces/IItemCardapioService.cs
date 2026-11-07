using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.ItemCardapio;

namespace Restaurante.Services.Interfaces
{
    public interface IItemCardapioService
    {
        Task<Resultado> ObterPorCardapioIdAsync(int cardapioId);
        Task<Resultado> ObterPorIdAsync(int cardapioId, int itemId);
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> CriarAsync(int cardapioId, int itemId, CriarItemCardapioDto dto);
        Task<Resultado> AtualizarAsync(int cardapioId, int itemId, AtualizarItemCardapioDto dto);
        Task<Resultado> DeletarAsync(int cardapioId, int itemId);
    }
}
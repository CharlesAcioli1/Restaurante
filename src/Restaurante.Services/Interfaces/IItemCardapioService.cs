using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.ItemCardapio;

namespace Restaurante.Services.Interfaces
{
    public interface IItemCardapioService
    {
        Task<Resultado> ObterPorIdAsync(int cardapioId, int itemId);
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> CriarAsync(CriarItemCardapioDto dto);
        Task<Resultado> AtualizarAsync(AtualizarItemCardapioDto dto);
        Task<Resultado> DeletarAsync(int cardapioId, int itemId);
    }
}

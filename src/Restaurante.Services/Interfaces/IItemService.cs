using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.ItemDto;

namespace Restaurante.Services.Interfaces
{
    public interface IItemService
    {
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterCozinhaIdAsync(int cozinhaId);
        Task<Resultado> CriarAsync(CriarItemDto dto);
        Task<Resultado> AtualizarAsync(AtualizarItemDto dto);
        Task<Resultado> DeletarAsync(int id);
    }
}

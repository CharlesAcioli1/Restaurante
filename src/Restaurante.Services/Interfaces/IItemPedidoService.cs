using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.ItemPedidoDto;

namespace Restaurante.Services.Interfaces
{
    public interface IItemPedidoService
    {
        Task<Resultado> ObterPorIdAsync(int pedidoId, int itemCardapioId, int statusId);
        Task<Resultado> CriarAsync(CriarItemPedidoDto dto);
        Task<Resultado> AtualizarAsync(AtualizarItemPedidoDto dto);
        Task<Resultado> DeletarAsync(int pedidoId, int itemCardapioId, int statusId);
    }
}
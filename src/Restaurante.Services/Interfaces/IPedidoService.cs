using Restaurante.Domain.Compartilhar;

using Restaurante.Services.DTOs.Pedido;

namespace Restaurante.Services.Interfaces;

public interface IPedidoService
{
    Task<Resultado> ObterTodosAsync();
    Task<Resultado> ObterPorIdAsync(int id);
    Task<Resultado> ObterPorIdMesaAsync(int mesaId);
    Task<Resultado> ObterPorStatusIdAsync(int statusPedido);
    Task<Resultado> ObterPorDataAsync(DateTime dateUtc);
    Task<Resultado> CriarAsync(CriarPedidoDto dto);
    Task<Resultado> AtualizarAsync(AtualizarPedidoDto dto);
    Task<Resultado> DeletarAsync(int id);
}
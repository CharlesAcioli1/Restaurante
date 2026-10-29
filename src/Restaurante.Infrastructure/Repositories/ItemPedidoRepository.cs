using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Restaurante.Infrastructure.Repositories
{
    public class ItemPedidoRepository(RestauranteDbContext context) : IItemPedidoRepository
    {
        private readonly RestauranteDbContext _context = context;

        public async Task<Resultado> AtualizarAsync(Dom.ItemPedido itemPedido)
        {
            try
            {
                _context.ItemPedidos.Update(itemPedido);
                await _context.SaveChangesAsync();
                return Resultado.Success(itemPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível atualizar item do pedido no banco de dados!");
            }
        }

        public async Task<Resultado> CriarAsync(Dom.ItemPedido itemPedido)
        {
            try
            {
                _context.ItemPedidos.Add(itemPedido);
                await _context.SaveChangesAsync();
                return Resultado.Success(itemPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível adicionar item ao pedido no banco de dados!");
            }
        }

        public async Task<Resultado> DeletarAsync(Dom.ItemPedido itemPedido)
        {
            try
            {
                _context.ItemPedidos.Remove(itemPedido);
                await _context.SaveChangesAsync();
                return Resultado.Success(itemPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível remover item do pedido no banco de dados");
            }
        }

        public async Task<Resultado> ObterPorIdAsync(int pedidoId, int itemCardapioId, int statusId)
        {
            try
            {
                var itemPedido = await _context.ItemPedidos
                    .Include(ip => ip.ItemCardapio)
                    .ThenInclude(ic => ic!.Item)
                    .Include(ip => ip.Status)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(ip => ip.PedidoId == pedidoId && ip.ItemCardapioId == itemCardapioId && ip.StatusId == statusId);
                return Resultado.Success(itemPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter resultados de status de itens pedidos no banco de dados!");
            }
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            try
            {
                var itemPedido = await _context.ItemPedidos
                    .Include (ip => ip.ItemCardapio)
                    .ThenInclude (ic => ic!.Item)
                    .Include (ip => ip.Status)
                    .AsNoTracking()
                    .ToListAsync();
                return Resultado.Success(itemPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível lista de itens e pedidos no banco de dados!");
            }
        }
    }
}

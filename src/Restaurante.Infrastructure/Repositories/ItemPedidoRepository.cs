using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Restaurante.Infrastructure.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly RestauranteDbContext _context;
        public ItemPedidoRepository(RestauranteDbContext context)
        {
            _context = context;
        }

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

        public async Task<Resultado> ObterPorItemIdAsync(int id)
        {
            try
            {
                var itemPedido = await _context.ItemPedidos
                .AsNoTracking()
                .Where(ip => ip.ItemId == id)
                .ToListAsync();
                return Resultado.Success(itemPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter ID do item do pedido no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorPedidoIdAsync(int id)
        {
            try
            {
                var itemPedido = await _context.ItemPedidos
                .AsNoTracking()
                .Where(ip => ip.PedidoId == id)
                .ToListAsync();
                return Resultado.Success(itemPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter ID do pedido dos itens pedidos no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorStatusId(int id)
        {
            try
            {
                var itemPedido = await _context.ItemPedidos
                    .AsNoTracking()
                    .Where (ip => ip.StatusId == id)
                    .ToListAsync();
                return Resultado.Success(itemPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter Status dos itens pedidos no banco de dados");
            }
        }
    }
}

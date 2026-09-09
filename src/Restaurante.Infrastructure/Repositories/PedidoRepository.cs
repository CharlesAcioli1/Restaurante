using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Dom = Restaurante.Domain;

namespace Restaurante.Infrastructure.Repositories
{
    internal class PedidoRepository : IPedidoRepository
    {
        private readonly RestauranteDbContext _context;
        public PedidoRepository(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<Resultado> AtualizarAsync(Pedido pedido)
        {
            try
            {
                _context.Pedidos.Update(pedido);
                await _context.SaveChangesAsync();
                return Resultado.Success(pedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível atualizar pedido no banco de dados!");
            }
        }

        public async Task<Resultado> CriarAsync(Pedido pedido)
        {
            try
            {
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();
                return Resultado.Success(pedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível criar novo pedido no banco de dados!");
            }
        }

        public async Task<Resultado> DeletarAsync(Pedido pedido)
        {
            try
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
                return Resultado.Success(pedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível deletar pedido do banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorDataAsync(DateTime dataUtc)
        {
            try
            {
                var inicioDoDia = dataUtc.Date;
                var fimDoDia = dataUtc.Date.AddDays(1).AddTicks(-1);

                var pedidos = await _context.Pedidos
                    .AsNoTracking()
                    .Where(p => p.DataCriacao >= inicioDoDia && p.DataCriacao <= fimDoDia)
                    .ToListAsync();
                return Resultado.Success(pedidos);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter data do pedido noi banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            try
            {
                var pedido = _context.Pedidos
                .AsNoTracking()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
                return Resultado.Success(pedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter ID do pedido no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorMesaIdAsync(int mesaId)
        {
            try
            {
                var pedido = await _context.Pedidos
                    .AsNoTracking()
                    .Where(p => p.IdMesa == mesaId)
                    .ToListAsync();
                return Resultado.Success(pedido);
            }
            catch (Exception)
            {
                return Resultado.Falha("Não foi possível obter ID da mesa do pedido no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorStatusIdAsync(int statusId)
        {
            try
            {
                var pedido = await _context.Pedidos
                .AsNoTracking()
                .Where(p => p.StatusId == statusId)
                .ToListAsync();
                return Resultado.Success(pedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter ID do status do pedido no banco de dados!");
            }
        }

        public async Task<Resultado> ObterTodasAsync()
        {
            try
            {
                var lista = await _context.Pedidos
                    .AsNoTracking()
                    .ToListAsync();
                return Resultado.Success(lista);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter lista de pedidos no banco de dados!");
            }
        }
    }
}

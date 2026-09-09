using Microsoft.EntityFrameworkCore;
using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;

namespace Restaurante.Infrastructure.Repositories
{
    public class FilaPedidoRepository : IFilaPedidoRepository
    {
        private readonly RestauranteDbContext _context;
        public FilaPedidoRepository(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<Resultado> ObterPorData(DateTime dateUtc)
        {
            try
            {
                var inicioDoDia = dateUtc.Date;
                var fimDoDia = dateUtc.Date.AddDays(1).AddTicks(-1);
                var filaPedido = await _context.FilaPedidos
                    .AsNoTracking()
                    .Where(fp => fp.DataHoraEntrada >= inicioDoDia && fp.DataHoraEntrada <= fimDoDia)
                    .ToListAsync();
                return Resultado.Success(filaPedido);

            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível data/hora da fila de pedidos no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            try
            {
                var filaPedido = await _context.FilaPedidos
                    .AsNoTracking()
                    .Where(fp => fp.Id == id)
                    .ToListAsync();
                return Resultado.Success(filaPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter fila de pedidos pelo ID no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorPedidoId(int id)
        {
            try
            {
                var filaPedido = await _context.FilaPedidos
                .AsNoTracking()
                .Where(fp => fp.Id == id)
                .ToListAsync();
                return Resultado.Success(filaPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter ID do pedido da fila de pedidos no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPosicaoAsync(int id)
        {
            try
            {
                var filaPedido = await _context.FilaPedidos
                    .AsNoTracking()
                    .Where(fp => fp.Id == id)
                    .Select(fp => fp.Id)
                    .ToListAsync();
                return Resultado.Success(filaPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível posição do pedido no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPrioridadeAsync(string prioridade)
        {
            try
            {
                var filaPedido = await _context.FilaPedidos
               .AsNoTracking()
               .Where(fp => fp.Prioridade.ToLower() == prioridade.ToLower())
               .OrderBy(fp => fp.DataHoraEntrada)
               .ToListAsync();
                return Resultado.Success(filaPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter prioridade de pedidos do banco de dados!");
            }
        }
    }
}

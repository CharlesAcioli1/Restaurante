using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;

namespace Restaurante.Infrastructure.Repositories
{
    public class FilaPedidoRepository(RestauranteDbContext context) : IFilaPedidoRepository
    {
        private readonly RestauranteDbContext _context = context;

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
                    .FirstOrDefaultAsync(fp => fp.Id == id);
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
                .FirstOrDefaultAsync(fp => fp.PedidoId == id);
                return Resultado.Success(filaPedido);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter ID do pedido da fila de pedidos no banco de dados!");
            }
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            try
            {
                var filaPedidos = await _context.FilaPedidos
                .AsNoTracking()
                .ToListAsync();

                return Resultado.Success(filaPedidos);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi póssível obter fila de pedidos no banco de dados!");
            }
        }
    }
}

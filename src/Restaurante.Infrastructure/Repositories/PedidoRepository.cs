using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;

namespace Restaurante.Infrastructure.Repositories
{
    public class PedidoRepository(RestauranteDbContext context) : IPedidoRepository
    {
        private readonly RestauranteDbContext _context = context;

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
            catch (Exception ex)
            {
                var erro = ex.ToString();
                Console.WriteLine(erro);
                return Resultado.Falha($"Erro ao criar pedido: {ex.GetBaseException().Message}");
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

        public async Task<Resultado> ObterPorDataAsync(PeriodoPedidoDto datas)
        {
            try
            {
                var pedidos = await _context.Pedidos
                    .AsNoTracking()
                    .Where(p => p.DataCriacao >= datas.PedidoInicio && p.DataCriacao <= datas.PedidoFim)
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
                var pedido = await _context.Pedidos
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
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
                    .Include(p => p.Itens)
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
                    .Include(p => p.Itens)
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

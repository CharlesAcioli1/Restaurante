using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Dom = Restaurante.Domain;

namespace Restaurante.Infrastructure.Repositories
{
    public class MesaRepository(RestauranteDbContext context) : IMesaRepository
    {
        private readonly RestauranteDbContext _context = context;

        public async Task<Resultado> AtualizarAsync(Dom.Mesa AtualizarMesa)
        {
            try
            {
                _context.Mesas.Update(AtualizarMesa);
                await _context.SaveChangesAsync();
                return Resultado.Success(AtualizarMesa);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível atualizar mesa no banco de dados!");
            }
        }

        public async Task<Resultado> CriarAsync(Dom.Mesa mesa)
        {
            try
            {
                _context.Mesas.Add(mesa);
                await _context.SaveChangesAsync();
                return Resultado.Success(mesa);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível criar mesa no banco de dados!");
            }
        }

        public async Task<Resultado> DeletarAsync(Dom.Mesa DeletarMesa)
        {
            try
            {
                _context.Mesas.Remove(DeletarMesa);
                await _context.SaveChangesAsync();
                return Resultado.Success(DeletarMesa);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível deletar mesa do banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            try
            {
                var mesa = await _context.Mesas
                .AsNoTracking()
                .Include(m => m.Restaurante)
                .Include(m => m.StatusMesa)
                .FirstOrDefaultAsync(m => m.Id == id);
                return Resultado.Success(mesa);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter mesa por ID no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId)
        {
            try
            {
                var listagem = await _context.Mesas
                .AsNoTracking()
                .Include(m => m.Restaurante)
                .Where(m => m.RestauranteId == restauranteId)
                .ToListAsync();
                return Resultado.Success(listagem);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter mesas pelo ID do restarurante no banco de dados!");
            }
        }

        public async Task<Resultado> ObterTodasAsync()
        {
            try
            {
                var lista = await _context.Mesas
                .AsNoTracking()
                .Include(m => m.Restaurante)
                .Include(m => m.StatusMesa)
                .ToListAsync();
                return Resultado.Success(lista);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter resultados do banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorStatusAsync(int restauranteId,  int statusMesaId)
        {
            try
            {
                var listagem = await _context.Mesas
                    .AsNoTracking()
                    .Include(m => m.Restaurante)
                    .Include(m => m.StatusMesa)
                    .Where(m => m.RestauranteId == restauranteId && m.StatusMesaId == statusMesaId)
                    .ToListAsync();

                return Resultado.Success(listagem);
            }
            catch (Exception)
            {
                return Resultado.Falha("Não foi possível filtrar mesas por status no banco de dados!");
            }
        }
    }
}

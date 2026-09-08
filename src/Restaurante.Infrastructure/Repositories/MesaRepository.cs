using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Dom = Restaurante.Domain;

namespace Restaurante.Infrastructure.Repositories
{
    public class MesaRepository : IMesaRepository
    {
        private readonly RestauranteDbContext _context;
        public MesaRepository(RestauranteDbContext context)
        {
            _context = context;
        }

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
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();
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
                var lista =  await _context.Mesas
                .AsNoTracking()
                .ToListAsync();
                return Resultado.Success(lista);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter resultados do banco de dados!");
            }
        }
    }
}

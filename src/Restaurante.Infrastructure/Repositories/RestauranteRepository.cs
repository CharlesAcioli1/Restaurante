using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Dom = Restaurante.Domain;

namespace Restaurante.Infrastructure.Repositories
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly RestauranteDbContext _context;
        public RestauranteRepository(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<Resultado> AtualizarAsync(Dom.Restaurante AtualizarRestaurante)
        {
            try
            {
                _context.Restaurantes.Update(AtualizarRestaurante);
                await _context.SaveChangesAsync();
                return Resultado.Success(AtualizarRestaurante);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível atualizar o restaurante no banco de dados!");
            }
        }

        public async Task<Resultado> CriarAsync(Dom.Restaurante novoRestaurante)
        {
            try
            {
                _context.Restaurantes.Add(novoRestaurante);
                await _context.SaveChangesAsync();
                return Resultado.Success(novoRestaurante);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível criar um novo restaurante no banco de dados!");
            }
        }

        public async Task<Resultado> DeletarAsync(Dom.Restaurante deletarRestaurante)
        {
            try
            {
                _context.Restaurantes.Remove(deletarRestaurante);
                await _context.SaveChangesAsync();
                return Resultado.Success(deletarRestaurante);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível apagar restaurante do banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            try
            {
                var restaurante = await _context.Restaurantes
                    .AsNoTracking()
                    .FirstOrDefaultAsync(r => r.Id == id);
                return Resultado.Success(restaurante);

            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter restaurante do banco de dados!");
            }
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            try
            {
                var lista = await _context.Restaurantes
                .AsNoTracking()
                .ToListAsync();
                return Resultado.Success(lista);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter lista de restaurante do banco de dados!");
            }

        }
    }
}

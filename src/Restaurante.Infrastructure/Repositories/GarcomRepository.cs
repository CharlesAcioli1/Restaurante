using Dom = Restaurante.Domain;
using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;

namespace Restaurante.Infrastructure.Repositories
{
    public class GarcomRepository : IGarcomRepository
    {
        private readonly RestauranteDbContext _context;
        public GarcomRepository(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<Resultado> AtualizarAsync(Dom.Garcom garcom)
        {
            try
            {
                _context.Garcons.Update(garcom);
                await _context.SaveChangesAsync();
                return Resultado.Success(garcom);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível atualizar garçom no banco de dados!");
            }
        }

        public async Task<Resultado> CriarAsync(Dom.Garcom novoGarcom)
        {
            try
            {
                _context.Garcons.Add(novoGarcom);
                await _context.SaveChangesAsync();
                return Resultado.Success(novoGarcom);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possóvel criar garçom no banco de dados!");
            }
        }

        public async Task<Resultado> DeletarAsync(Dom.Garcom garcom)
        {
            try
            {
                _context.Garcons.Remove(garcom);
                await _context.SaveChangesAsync();
                return Resultado.Success(garcom);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não é possível remover garçom do banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            try
            {
                var garcom = await _context.Garcons
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);
                return Resultado.Success(garcom);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter garçom por ID no banco de dados!");
            }
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            try
            {
                var lista = await _context.Garcons
                .AsNoTracking()
                .ToListAsync();
                return Resultado.Success(lista);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter lista de garçom do banco de dados!");
            }
        }
    }
}

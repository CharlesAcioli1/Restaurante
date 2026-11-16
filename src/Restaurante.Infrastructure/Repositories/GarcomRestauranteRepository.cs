using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;

namespace Restaurante.Infrastructure.Repositories
{
    public class GarcomRestauranteRepository(RestauranteDbContext context) : IGarcomRestauranteRepository
    {
        private readonly RestauranteDbContext _context = context;

        public async Task<Resultado> ObterPorIdAsync(int garcomId, int restauranteId)
        {
            try
            {
                var garcomRestaurante = await _context.GarcomRestaurantes
                .AsNoTracking()
                .Include(gr => gr.Garcom)
                .Include(gr => gr.Restaurante)
                .FirstOrDefaultAsync(gr => gr.GarcomId == garcomId && gr.RestauranteId == restauranteId);

                if (garcomRestaurante == null)
                    return Resultado.Falha("Vínculo não encontrado!");

                return Resultado.Success(garcomRestaurante);
            }
            catch (Exception)
            {
                return Resultado.Falha("Não foi possível obter informações de garçom no banco de dados!");
            }
        }

        public async Task<Resultado> CriarVinculoAsync(GarcomRestaurante garcomRestaurante)
        {
            try
            {
                _context.GarcomRestaurantes.Add(garcomRestaurante);
                await _context.SaveChangesAsync();
                var vinculoCriado = await _context.GarcomRestaurantes
                    .AsNoTracking()
                    .Include(gr => gr.Garcom)
                    .Include(gr => gr.Restaurante)
                    .FirstOrDefaultAsync(gr => gr.GarcomId == garcomRestaurante.GarcomId && gr.RestauranteId == garcomRestaurante.RestauranteId);
                return Resultado.Success(vinculoCriado);
            }
            catch (Exception)
            {

                return Resultado.Falha("Houve uma falha na criação ou há vínculos!");
            }
        }

        public async Task<Resultado> DeletarAsync(GarcomRestaurante garcomRestaurante)
        {
            try
            {
                _context.GarcomRestaurantes.Remove(garcomRestaurante);
                await _context.SaveChangesAsync();
                return Resultado.Success(garcomRestaurante);
            }
            catch (Exception)
            {

                return Resultado.Falha("Houve uma falha na exclusão ou não existe mais no banco de dados!");
            }
        }
    }
}

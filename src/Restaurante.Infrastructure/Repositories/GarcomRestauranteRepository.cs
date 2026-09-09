using Dom = Restaurante.Domain;
using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;

namespace Restaurante.Infrastructure.Repositories
{
    public class GarcomRestauranteRepository : IGarcomRestauranteRepository
    {
        private readonly RestauranteDbContext _context;

        public GarcomRestauranteRepository(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<Resultado> ObterPorData(DateTime dateUtc)
        {
            try
            {
                var inicioDoDia = DateTime.SpecifyKind(dateUtc.Date, DateTimeKind.Utc);
                var fimDoDia = inicioDoDia.AddDays(1).AddTicks(1);
                var garcomRestaurante = await _context.GarcomRestaurantes
                    .AsNoTracking()
                    .Where(gr => gr.DataInicio >= inicioDoDia && gr.DataInicio <= fimDoDia)
                    .ToListAsync();
                return Resultado.Success(garcomRestaurante);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter datas de garçom e restaurante!");
            }
        }

        public async Task<Resultado> ObterPorGarcomId(int id)
        {
            try
            {
                var garcomRestaurante = await _context.GarcomRestaurantes
                .AsNoTracking()
                .Where(gr => gr.GarcomId == id)
                .ToListAsync();
                return Resultado.Success(garcomRestaurante);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter informações de garçom para o restaurante no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorRestauranteId(int id)
        {
            try
            {
                var garcomRestaurante = await _context.GarcomRestaurantes
                .AsNoTracking()
                .Where(gr => gr.RestauranteId == id)
                .ToListAsync();
                return Resultado.Success(garcomRestaurante);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter informações de restaurantes para garçom!");
            }
        }

        public async Task<Resultado> ObterPorStatusId(int id)
        {
            try
            {
                var garcomRestaurante = await _context.GarcomRestaurantes
                .AsNoTracking()
                .Where(gr => gr.StatusId == id)
                .ToListAsync();
                return Resultado.Success(garcomRestaurante);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter Status do garçom e mesa!");
            }
        }
    }
}

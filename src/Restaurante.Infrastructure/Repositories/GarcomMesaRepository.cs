using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Dom = Restaurante.Domain;

namespace Restaurante.Infrastructure.Repositories
{
    public class GarcomMesaRepository : IMesaGarcomRepository
    {
        private readonly RestauranteDbContext _context;
        public GarcomMesaRepository(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<Resultado> ObterPorIdGarcom(int id)
        {
            try
            {
                var garcomMesa = await _context.GarcomMesas
                .AsNoTracking()
                .Where(gm => gm.GarcomId == id)
                .ToListAsync();
                return Resultado.Success(garcomMesa);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter informações do garçom no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorIdMesa(int id)
        {
            try
            {
                var garcomMesa = await _context.GarcomMesas
                    .AsNoTracking()
                    .Where(gm => gm.MesaId == id)
                    .ToListAsync();
                return Resultado.Success(garcomMesa);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter informações da mesa no banco de dados!");
            }
        }
    }
}

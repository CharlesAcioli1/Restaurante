using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Dom = Restaurante.Domain;

namespace Restaurante.Infrastructure.Repositories
{
    public class GarcomMesaRepository(RestauranteDbContext context) : IMesaGarcomRepository
    {
        private readonly RestauranteDbContext _context = context;

        public async Task<Resultado> ObterPorIdGarcom(int id)
        {
            try
            {
                var obterIdGarcom = await _context.GarcomMesas
                .AsNoTracking()
                .Where(gm => gm.GarcomId == id)
                .ToListAsync();
                return Resultado.Success(obterIdGarcom);
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
                var obterIdMesa = await _context.GarcomMesas
                    .AsNoTracking()
                    .Include(gm => gm.Mesa)
                    .ThenInclude(m => m!.Restaurante)
                    .Where(gm => gm.MesaId == id)
                    .ToListAsync();
                return Resultado.Success(obterIdMesa);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter informações da mesa no banco de dados!");
            }
        }

        public async Task<Resultado> AbrirMesaAsync(GarcomMesa garcomMesa)
        {
            try
            {
                _context.GarcomMesas.Add(garcomMesa);
                await _context.SaveChangesAsync();
                return Resultado.Success(garcomMesa);
            }
            catch (Exception ex)
            {

                return Resultado.Falha($"Erro ao abrir mesa: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        public async Task<Resultado>FecharMesaAsync(GarcomMesa garcomMesa)
        {
            try
            {
                _context.GarcomMesas.Remove(garcomMesa);
                await _context.SaveChangesAsync();
                return Resultado.Success(garcomMesa);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível fechar a mesa!");
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Services.DTOs.Mesa;
using Restaurante.Services.Interfaces;


namespace Restaurante.Services.Implementations
{
    public class MesaService : IMesaService
    {
        private readonly RestauranteDbContext _context;

        public MesaService(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MesaResponseDto>> ObterTodasAsync()
        {
            return await _context.Mesas
                .AsNoTracking()
                .Select(m => new MesaResponseDto
                {
                    Id = m.Id,
                    Numero = m.Numero,
                    StatusId = m.StatusId,
                    RestauranteId = m.RestauranteId
                })
                .ToListAsync();
        }

        public async Task<MesaResponseDto?> ObterPorIdAsync( int id)
        {
            return await _context.Mesas
                .AsNoTracking()
                .Where(m => m.Id == id)
                .Select(m => new MesaResponseDto
                {
                    Id = m.Id,
                    Numero = m.Numero,
                    StatusId = m.StatusId,
                    RestauranteId = m.RestauranteId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<MesaResponseDto> CriarAsync(MesaResponseDto dto)
        {
            var mesa = new Mesa
            {
                Numero = dto.Numero,
                StatusId = dto.StatusId,
                RestauranteId = dto.RestauranteId
            };

            _context.Mesas .Add(mesa);
            await _context.SaveChangesAsync();

            return new MesaResponseDto
            {
                Id = mesa.Id,
                Numero = mesa.Numero,
                StatusId = mesa.StatusId,
                RestauranteId = mesa.RestauranteId
            };
        }

        public async Task<bool> AtualizarAsync(AtualizarMesaDto dto)
        {
            var mesa = await _context.Mesas.FindAsync(dto.Id);

            if(mesa == null)
                return false;

            mesa.Numero = dto.Numero;
            mesa.StatusId = dto.StatusId;

            _context.Mesas.Update(mesa);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeletarAsync(int id)
        {
            var mesa = await _context.Mesas.FindAsync(id);

            if (mesa == null)
                return false;

            _context.Mesas.Remove(mesa);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
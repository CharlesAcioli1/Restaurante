using Microsoft.EntityFrameworkCore;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Services.DTOs;
using Restaurante.Services.Interfaces;
using DomainEntity = Restaurante.Domain.Garcom;


namespace Restaurante.Services.Implementations
{
    public class GarcomService : IGarcomService
    {
        private readonly RestauranteDbContext _context;

        public GarcomService(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GarcomResponseDto>> ObterTodosAsync()
        {
            return await _context.Garcons
                .AsNoTracking()
                .Select(g => new GarcomResponseDto
                {
                    Id = g.Id,
                    Nome = g.Nome,
                    Cpf = g.Cpf,
                    Telefone = g.Telefone
                })
                .ToListAsync();
        }

        public async Task<GarcomResponseDto?> ObterPorIdAsync(int id)
        {
            var garcom = await _context.Garcons
                .AsNoTracking()
                .FirstOrDefaultAsync(g => g.Id == id);

            if (garcom == null) return null;

            return new GarcomResponseDto
            {
                Id = garcom.Id,
                Nome = garcom.Nome,
                Cpf = garcom.Cpf,
                Telefone = garcom.Telefone
            };
        }

        public async Task<GarcomResponseDto> CriarAsync(CriarGarcomDto dto)
        {
            var novoGarcom = new DomainEntity
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Telefone = dto.Telefone
            };

            _context.Garcons.Add(novoGarcom);
            await _context.SaveChangesAsync();

            return new GarcomResponseDto
            {
                Id = novoGarcom.Id,
                Nome = novoGarcom.Nome,
                Cpf = novoGarcom.Cpf,
                Telefone = novoGarcom.Telefone
            };
        }

        public async Task<GarcomResponseDto?> AtualizarAsync(int id, AtualizarGarcomDto dto)
        {
            var garcom = await _context.Garcons.FindAsync(id);
            if (garcom == null) return null;

            if(!string.IsNullOrEmpty(dto.Nome))
            {
                garcom.Nome = dto.Nome;
            }

            if(!string.IsNullOrEmpty(dto.Cpf))
            {
                garcom.Cpf = dto.Cpf;
            }

            if(!string.IsNullOrEmpty(dto.Telefone))
            {
                garcom.Telefone = dto.Telefone;
            }

            //FORMA ANTERIOR, SEM O TRATAMENTO DO ERROS!
            //garcom.Nome = dto.Nome;
            //garcom.Cpf = dto.Cpf;
            //garcom.Telefone = dto.Telefone;

            _context.Garcons.Update(garcom);
            await _context.SaveChangesAsync();

            return new GarcomResponseDto
            {
                Id = garcom.Id,
                Nome = garcom.Nome,
                Cpf = garcom.Cpf,
                Telefone = garcom.Telefone
            };
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var garcom = await _context.Garcons.FindAsync(id);
            if(garcom == null) return false;

            _context.Garcons.Remove(garcom);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
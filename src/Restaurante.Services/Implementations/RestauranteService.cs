using Microsoft.EntityFrameworkCore;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Services.DTOs.Restaurante;
using Restaurante.Services.Interfaces;
using DomainEntity = Restaurante.Domain.Restaurante;

namespace Restaurante.Services.Implementations;

public class RestauranteService : IRestauranteService
{
    private readonly RestauranteDbContext _context;

    public RestauranteService(RestauranteDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<RestauranteResponseDto>> ObterTodosAsync()
        {
            return await _context.Restaurantes
                .AsNoTracking()
                .Select(r => new RestauranteResponseDto
                {
                    Id = r.Id,
                    Nome = r.Nome,
                    Cnpj = r.Cnpj,
                    Email = r.Email,
                    Endereco = r.Endereco,
                    Telefone = r.Telefone
                })
                .ToListAsync();
        }

    public async Task<RestauranteResponseDto?> ObterPorIdAsync(int Id)
    {
        var restaurante = await _context.Restaurantes
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == Id);

        if (restaurante == null) return null;

        return new RestauranteResponseDto
        {
            Id = restaurante.Id,
            Nome = restaurante.Nome,
            Cnpj = restaurante.Cnpj,
            Email = restaurante.Email,
            Endereco = restaurante.Endereco,
            Telefone = restaurante.Telefone
        };
    }

    public async Task<RestauranteResponseDto> CriarAsync(CriarRestauranteDto dto)
    {
        var novoRestaurante = new DomainEntity(
            dto.Nome,
            dto.Cnpj,
            dto.Email,
            dto.Endereco,
            dto.Telefone
            );

        _context.Restaurantes.Add( novoRestaurante );
        await _context.SaveChangesAsync();

        return new RestauranteResponseDto
        {
            Id = novoRestaurante.Id,
            Nome = novoRestaurante.Nome,
            Cnpj = novoRestaurante.Cnpj,
            Email = novoRestaurante.Email,
            Telefone = novoRestaurante.Telefone
        };
    }

    public async Task<RestauranteResponseDto?> AtualizarAsync(int Id, AtualizarRestauranteDto dto)
    {
        var restaurante = await _context.Restaurantes.FindAsync(Id);
        if (restaurante == null) return null;

        restaurante.Nome = dto.Nome;
        restaurante.Endereco = dto.Endereco;
        restaurante.AtualizarEmail(dto.Email);
        restaurante.AtualizarTelefone(dto.Telefone);

        _context.Restaurantes.Update(restaurante);
        await _context.SaveChangesAsync();

        return new RestauranteResponseDto
        {
            Id = restaurante.Id,
            Nome = restaurante.Nome,
            Cnpj = restaurante.Cnpj,
            Email = restaurante.Email,
            Endereco = restaurante.Endereco,
            Telefone = restaurante.Telefone
        };
    }

    public async Task<bool> DeletarAsync(int Id)
    {
        var restaurante = await _context.Restaurantes.FindAsync(Id);
        if(restaurante == null) return false;

        _context.Restaurantes.Remove(restaurante);
        await _context.SaveChangesAsync();
        return true;
    }
}





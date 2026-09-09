using Microsoft.EntityFrameworkCore;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Services.DTOs.Cardapio;
using Restaurante.Services.Interfaces;
using DomainEntity = Restaurante.Domain.Cardapio;

namespace Restaurante.Services.Implementations
{
    public class CardapioService : ICardapioService
    {
        private readonly RestauranteDbContext _context;

        public CardapioService (RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CardapioResponseDto>> ObterTodosAsync()
        {
            return await _context.Cardapios
                .AsNoTracking()
                .Select(c => new CardapioResponseDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    RestauranteId = c.RestauranteId
                })
                .ToListAsync();
        }

        public async Task<CardapioResponseDto?> ObterPorIdAsync(int id)
        {
            var cardapio = await _context.Cardapios
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if(cardapio == null)
                return null;

            return new CardapioResponseDto
            {
                Id = cardapio.Id,
                Nome = cardapio.Nome,
                RestauranteId = cardapio.RestauranteId
            };
        }

        public async Task<IEnumerable<CardapioResponseDto>> ObterPorRestauranteIdAsync(int restauranteId)
        {
            return await _context.Cardapios
                .AsNoTracking()
                .Where(c => c.RestauranteId == restauranteId)
                .Select(c => new CardapioResponseDto
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    RestauranteId = c.RestauranteId
                })
                .ToListAsync();
        }

        public async Task<CardapioResponseDto> CriarCardapioAsync(CriarCardapioDto dto)
        {
            var novoCardapio = new DomainEntity
            {
                Nome = dto.Nome
            };
            _context.Cardapios.Add(novoCardapio);
            await _context.SaveChangesAsync();

            return new CardapioResponseDto
            {
                Id = novoCardapio.Id,
                Nome = novoCardapio.Nome,
                RestauranteId = novoCardapio.RestauranteId
            };
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var cardapio = await _context.Cardapios.FindAsync(id);
            if (cardapio == null) return false;
            _context.Cardapios.Remove(cardapio);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<CardapioResponseDto?> AtualizarCardapioAsync(AtualizarCardapioDto dto)
        {
            var cardapio = await _context.Cardapios.FindAsync();
            if(cardapio == null) return null;

            _context.Cardapios.Update(cardapio);
            await _context.SaveChangesAsync();

            return new CardapioResponseDto
            {
                Id = cardapio.Id,
                Nome = cardapio.Nome,
                RestauranteId = cardapio.RestauranteId
            };
        }
    }
}
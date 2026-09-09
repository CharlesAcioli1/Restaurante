using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;

namespace Restaurante.Infrastructure.Repositories
{
    public class CardapioRepository : ICardapioRepository
    {
        private readonly RestauranteDbContext _context;

        public CardapioRepository(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<Resultado> AtualizarCardapioAsync(Cardapio cardapio)
        {
            try
            {
                _context.Cardapios.Update(cardapio);
                await _context.SaveChangesAsync();
                return Resultado.Success(cardapio);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível atualizar cardápio no banco de dados!");
            }
        }

        public async Task<Resultado> CriarCardapioAsync(Cardapio novoCardapio)
        {
            try
            {
                _context.Cardapios.Add(novoCardapio);
                await _context.SaveChangesAsync();
                return Resultado.Success(novoCardapio);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível criar um novo cardápio no banco de dados");
            }
        }

        public async Task<Resultado> DeletarAsync(Cardapio cardapio)
        {
            try
            {
                _context.Cardapios.Remove(cardapio);
                await _context.SaveChangesAsync();
                return Resultado.Success(cardapio);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não é possível excluir cardápio do banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            try
            {
                var cardapio = await _context.Cardapios
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
                return Resultado.Success(cardapio);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter cardápio por ID no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId)
        {
            try
            {
                var restaurantePorId = await _context.Cardapios
                .AsNoTracking()
                .Where(c => c.RestauranteId == restauranteId)
                .ToListAsync();
                return Resultado.Success(restaurantePorId);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não é possível obter cardápio pelo ID do restaurante!");
            }

        }

        public async Task<Resultado> ObterTodosAsync()
        {
            try
            {
                var lista = await _context.Cardapios
                .AsNoTracking()
                .ToListAsync();
                return Resultado.Success(lista);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter lista de resultados do banco de dados!");
            }
        }
    }
}

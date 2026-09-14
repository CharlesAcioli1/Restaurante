using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;

namespace Restaurante.Infrastructure.Repositories
{
    public class ItemCardapioRepository : IItemCardapioRepository
    {
        private readonly RestauranteDbContext _context;

        public ItemCardapioRepository(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<Resultado> AtualizarAsync(ItemCardapio itemCardapio)
        {
            try
            {
                _context.ItemCardapios.Update(itemCardapio);
                await _context.SaveChangesAsync();
                return Resultado.Success(itemCardapio);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível atualizar itemCardapio no banco de dados!");
            }
        }

        public async Task<Resultado> CriarAsync(ItemCardapio itemCardapio)
        {
            try
            {
                _context.ItemCardapios.Add(itemCardapio);
                await _context.SaveChangesAsync();
                return Resultado.Success(itemCardapio);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível criar itens do cardápio no baco de dados!");
            }
        }

        public async Task<Resultado> DeletarAsync(ItemCardapio itemCardapio)
        {
            try
            {
                _context.ItemCardapios.Remove(itemCardapio);
                await _context.SaveChangesAsync();
                return Resultado.Success(itemCardapio);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível excluir itens do cardápio no banco de dados");
            }
        }

        public async Task<Resultado> ObterPorCardapioIdAsync(int id)
        {
            try
            {
                var itemCardapio = await _context.ItemCardapios
                .AsNoTracking()
                .Where(ic => ic.CardapioId == id)
                .ToListAsync();
                return Resultado.Success(itemCardapio);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter Id do cardápio em itemCardapio no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorIdAsync(int cardpioId, int itemId)
        {
            try
            {
                var item = await _context.ItemCardapios
                .FirstOrDefaultAsync(i => i.CardapioId == cardpioId && i.ItemId == itemId);
                return Resultado.Success(item);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter ID's de item e cardápio no banco de dados!");
            }
        }

        public async Task<Resultado> ObterPrecoAsync(decimal preco)
        {
            try
            {
                var itens = await _context.ItemCardapios
                .AsNoTracking()
                .Where(ic => ic.Preco == preco)
                .ToListAsync();

                return Resultado.Success(itens);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi póssível obter preço dos itens do cardápio no banco de dados!");
            }
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            try
            {
                var lista = await _context.ItemCardapios
                    .AsNoTracking()
                    .ToListAsync();
                return Resultado.Success(lista);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter lista de itens e cardápios no banco de dados!");
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;

namespace Restaurante.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly RestauranteDbContext _context;
        public ItemRepository(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<Resultado> AtualizarAsync(Dom.Item item)
        {
            try
            {
                _context.Items.Update(item);
                await _context.SaveChangesAsync();
                return Resultado.Success(item);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível atualizar item no banco de dados!");
            }
        }

        public async Task<Resultado> CriarAsync(Dom.Item item)
        {
            try
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return Resultado.Success(item);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível adicionar item no banco de dados!");
            }
        }

        public async Task<Resultado> DeletarAsync(Dom.Item item)
        {
            try
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return Resultado.Success(item);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível remover item do banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorCozinhaId(int id)
        {
            try
            {
                var cozinhaId = await _context.Items
                    .AsNoTracking()
                    .Where(cz => cz.CozinhaId == id)
                    .ToListAsync();
                return Resultado.Success(cozinhaId);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não é possível obter ID da cozinha do item!");
            }
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            try
            {
                var item = await _context.Items
                .AsNoTracking()
                .Where(cz => cz.Id == id)
                .FirstOrDefaultAsync();
                return Resultado.Success(item);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter ID do item!");
            }
        }

        public async Task<Resultado> ObterTodasAsync()
        {
            try
            {
                var lista = await _context.Items
                    .AsNoTracking()
                    .ToListAsync();
                return Resultado.Success(lista);
            }
            catch (Exception)
            {

                return Resultado.Falha("Não foi possível obter lista de itens do banco de dodos!");
            }
        }
    }
}

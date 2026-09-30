using Microsoft.EntityFrameworkCore;
using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Persistencia;
using Restaurante.Infrastructure.Repositories.Interfaces;

namespace Restaurante.Infrastructure.Repositories
{
    public class CozinhaRepository(RestauranteDbContext context) : ICozinhaRepository
    {
        private readonly RestauranteDbContext _context = context;

        public async Task<Resultado> AtualizarAsync(Cozinha cozinha)
        {
            try
            {
                _context.Cozinhas.Update(cozinha);
                await _context.SaveChangesAsync();
                return Resultado.Success(cozinha);
            }
            catch (Exception)
            {
                return Resultado.Falha("Não foi possível atualizar cozinha no banco de dados!");
            }
        }

        public async Task<Resultado> CriarAsync(Cozinha cozinha)
        {
            try
            {
                _context.Cozinhas.Add(cozinha);
                await _context.SaveChangesAsync();
                return Resultado.Success(cozinha);
            }
            catch (Exception ex)
            {
                var mensagem = ex.InnerException?.Message ?? ex.Message;
                return Resultado.Falha($"Erro de Banco: {mensagem}");
            }
        }

        public async Task<Resultado> DeletarAsync(Cozinha cozinha)
        {
            try
            {
                _context.Cozinhas.Remove(cozinha);
                await _context.SaveChangesAsync();
                return Resultado.Success(cozinha);
            }
            catch (Exception)
            {
                return Resultado.Falha("Não foi possível remover cozinha do banco de dados!");
            }
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            try
            {
                var cozinha = await _context.Cozinhas
                    .FirstOrDefaultAsync(c => c.Id == id);
                return Resultado.Success(cozinha);
            }
            catch (Exception)
            {
                return Resultado.Falha("Não foi possível obter ID da cozinha!");
            }
        }

        public async Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId)
        {
            try
            {
                var cozinhas = await _context.Cozinhas
                    .AsNoTracking()
                    .Where(c => c.RestauranteId == restauranteId)
                    .ToListAsync();
                return Resultado.Success(cozinhas);
            }
            catch (Exception)
            {
                return Resultado.Falha("Não é possível obter cozinha pelo ID do restaurante!");
            }
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            try
            {
                var lista = await _context.Cozinhas
                    .AsNoTracking()
                    .ToListAsync();
                return Resultado.Success(lista);
            }
            catch (Exception)
            {
                return Resultado.Falha("Não foi possível obter lista de cozinhas do banco de dados!");
            }
        }
    }
}

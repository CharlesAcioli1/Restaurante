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
            // O QUE FAZ: Busca a mesa cadastrada para aplicar as alterações.

            // O QUE DIZ: "Execute uma busca assíncrona no DbSet 'Mesas' usando
            //o campo 'Id' recebido no DTO como chave primária e armazene a 
            //referência na variável 'mesa'."
            var mesa = await _context.Mesas.FindAsync(dto.Id);

            // O QUE FAZ: Valida se a mesa realmente existe no banco antes de prosseguir.
            // O QUE DIZ: "Se o objeto 'mesa' for nulo (não encontrado no banco),
            //interrompa a execução do método imediatamente e retorne 'false'."
            if (mesa == null)
                return false;

            // O QUE FAZ: Atualiza o número da mesa somente se um novo valor tiver sido enviado.
            // O QUE DIZ: "Verifique se a propriedade anulável 'Numero' possui algum valor
            // preenchido (diferente de null). Se possuir, atribua o valor interno de 'dto.Numero'
            // para a propriedade 'Numero' da entidade 'mesa'."
            if (dto.Numero.HasValue)
                mesa.Numero = dto.Numero.Value;

            // O QUE FAZ: Atualiza o status da mesa (ex: de Livre para Ocupada) somente se o status for informado.
            // O QUE DIZ: "Verifique se a propriedade anulável 'StatusId' possui algum valor preenchido (diferente de null).
            // Se possuir, atribua o valor interno de 'dto.StatusId' para a propriedade 'StatusId' da entidade 'mesa'."
            if (dto.StatusId.HasValue)
                mesa.StatusId = dto.StatusId.Value;

            // O QUE FAZ: Notifica o Entity Framework que o objeto teve suas propriedades modificadas.
            // O QUE DIZ: "Defina o estado da entidade 'mesa' dentro do contexto da aplicação como
            // 'Modified' (Modificado)."
            _context.Mesas.Update(mesa);

            // O QUE FAZ: Persiste as alterações no banco de dados e confirma se algum registro foi alterado.
            // O QUE DIZ: "Envie o comando SQL de UPDATE para o banco de forma assíncrona; se o número de linhas
            // afetadas retornado pelo banco for maior que 0, retorne 'true', caso contrário retorne 'false'."
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
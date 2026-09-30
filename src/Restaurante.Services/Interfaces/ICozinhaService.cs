using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.CozinhaDto;

namespace Restaurante.Services.Interfaces
{
    public interface ICozinhaService
    {
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId);
        Task<Resultado> CriarAsync(CriarCozinhaDto dto);
        Task<Resultado> AtualizarAsync(int id, AtualizarCozinhaDto dto);
        Task<Resultado> DeletarAsync(int id);
    }
}

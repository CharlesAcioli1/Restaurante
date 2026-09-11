using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs;
using Restaurante.Services.DTOs.Garcom;

namespace Restaurante.Services.Interfaces
{
    public interface IGarcomService
    {
        Task<Resultado> ObterTodosAsync();
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> CriarAsync(CriarGarcomDto dto);
        Task<Resultado> AtualizarAsync(AtualizarGarcomDto dto);
        Task<Resultado> DeletarAsync(int id);
    }
}
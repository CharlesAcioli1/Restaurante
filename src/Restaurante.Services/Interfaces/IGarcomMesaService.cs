using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.GarcomMesaDto;

namespace Restaurante.Services.Interfaces
{
    public interface IGarcomMesaService
    {
        Task<Resultado> ObterPorIdGarcom(int id);
        Task<Resultado> ObterPorIdMesa(int id);
        Task<Resultado> AbrirMesaAsync(int mesaId, int garcomId);
        Task<Resultado> FecharMesaAsync(int mesaId, int garcomId);
    }
}

using Restaurante.Domain.Compartilhar;

namespace Restaurante.Services.Interfaces
{
    public interface IGarcomMesaService
    {
        Task<Resultado> ObterPorIdGarcom(int id);
        Task<Resultado> ObterPorIdMesa(int id);
    }
}

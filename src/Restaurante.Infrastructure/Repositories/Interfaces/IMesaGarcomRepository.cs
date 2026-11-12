using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IMesaGarcomRepository
    {
        Task<Resultado> ObterPorIdMesa(int id);
        Task<Resultado> ObterPorIdGarcom(int id);
        Task<Resultado> AbrirMesaAsync(GarcomMesa garcomMesa);
        Task<Resultado> FecharMesaAsync(GarcomMesa garcomMesa);
    }
}

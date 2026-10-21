using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.GarcomMesaDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
    public class GarcomMesaService(IMesaGarcomRepository mesaGarcomRepository) : IGarcomMesaService
    {
        private readonly IMesaGarcomRepository _mesaGarcomRepository  = mesaGarcomRepository;

        public async Task<Resultado> ObterPorIdGarcom(int id)
        {
            var garcomId = await _mesaGarcomRepository.ObterPorIdGarcom(id);
            if (!garcomId.PossuiDados)
                return garcomId;

            var resultado = GarcomMesaResponseDto.GarcomMesaToDo((GarcomMesa)garcomId.Dados!);
            return Resultado.Success(resultado);
        }

        public async Task<Resultado> ObterPorIdMesa(int id)
        {
            var mesaId = await _mesaGarcomRepository.ObterPorIdMesa(id);
            if(!mesaId.PossuiDados)
                return mesaId;

            var resultado = GarcomMesaResponseDto.GarcomMesaToDo((GarcomMesa)mesaId.Dados!);
            return Resultado.Success(resultado);
        }
    }
}

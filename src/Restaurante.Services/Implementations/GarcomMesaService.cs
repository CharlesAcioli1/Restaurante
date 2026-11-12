using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Domain.Enums;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.GarcomMesaDto;
using Restaurante.Services.DTOs.Mesa;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
    public class GarcomMesaService(IMesaGarcomRepository mesaGarcomRepository, IMesaRepository mesaRepository,
        IGarcomRepository garcomRepository) : IGarcomMesaService
    {
        private readonly IMesaGarcomRepository _mesaGarcomRepository = mesaGarcomRepository;
        private readonly IMesaRepository _mesaRepository = mesaRepository;
        private readonly IGarcomRepository _garcomRepository = garcomRepository;

        public async Task<Resultado> ObterPorIdGarcom(int id)
        {
            var garcomId = await _mesaGarcomRepository.ObterPorIdGarcom(id);
            if (!garcomId.PossuiDados)
                return garcomId;

            if (garcomId.Dados is not List<GarcomMesa> garcoms)
                return Resultado.Falha("Erro ao obter os dados do garçom!");

            var resultado = garcoms.Select(GarcomMesaResponseDto.GarcomMesaToDo).ToList();
            return Resultado.Success(resultado);
        }

        public async Task<Resultado> ObterPorIdMesa(int id)
        {
            var mesaId = await _mesaGarcomRepository.ObterPorIdMesa(id);
            if (!mesaId.PossuiDados)
                return mesaId;

            if (mesaId.Dados is not List<GarcomMesa> mesas)
                return Resultado.Falha("Erro ao obter os dados da mesa!");

            var resultado = mesas.Select(GarcomMesaResponseDto.GarcomMesaToDo).ToList();
            return Resultado.Success(resultado);
        }

        public async Task<Resultado> AbrirMesaAsync(int mesaId, int garcomId)
        {
            var garcomResultado = await _garcomRepository.ObterPorIdAsync(garcomId);
            if (!garcomResultado.PossuiDados)
                return Resultado.Falha("Garçom não encontrado!");

            var mesaResultado = await _mesaRepository.VerificarMesaDesocupada(mesaId);
            if (!mesaResultado.PossuiDados || !(bool)mesaResultado.Dados!)
                return Resultado.Falha("Mesa não existe ou ocupada!");

            var obterId = await _mesaRepository.ObterPorIdAsync(mesaId);
            if (!obterId.PossuiDados)
                return Resultado.Falha("Mesa não encontrada!");

            var mesa = (Mesa)obterId.Dados!;

            mesa.StatusMesaId = (int)StatusMesaEnum.Ocupada;

            var atualizarStatusMesa = await _mesaRepository.AtualizarAsync(mesa);
            if (!atualizarStatusMesa.Sucesso)
                return atualizarStatusMesa;

            var garcomMesa = new GarcomMesa
            {
                GarcomId = garcomId,
                MesaId = mesaId,
                Mesa = mesa
            };

            var resultado = await _mesaGarcomRepository.AbrirMesaAsync(garcomMesa);
            if (!resultado.Sucesso)
                return resultado;
            return Resultado.Success(GarcomMesaResponseDto.GarcomMesaToDo(garcomMesa));
        }

        public async Task<Resultado> FecharMesaAsync(int mesaId, int garcomId)
        {
            var garcomResultado = await _garcomRepository.ObterPorIdAsync(garcomId);
            if (!garcomResultado.PossuiDados)
                return Resultado.Falha("Garçom não encontrado!");

            var mesaResultado = await _mesaRepository.ObterPorIdAsync(mesaId);
            if (!mesaResultado.PossuiDados)
                return Resultado.Falha("Mesa não encontrada!");

            var garcomMesa = new GarcomMesa
            {
                MesaId = mesaId,
                GarcomId = garcomId
            };

            var resultado = await _mesaGarcomRepository.FecharMesaAsync(garcomMesa);
            if (!resultado.Sucesso)
                return resultado;

            return Resultado.Success(GarcomMesaResponseDto.GarcomMesaToDo(garcomMesa));
        }
    }
}
using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs;
using Restaurante.Services.DTOs.Garcom;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
    public class GarcomService(IGarcomRepository garcomRepository) : IGarcomService
    {
        private readonly IGarcomRepository _garcomRepository = garcomRepository;
        public async Task<Resultado> ObterTodosAsync()
        {
            var resultado = await _garcomRepository.ObterTodosAsync();
            if (!resultado.PossuiDados)
                return resultado;

            var listaGarcom = (List<Garcom>)resultado.Dados!;
            var listaDto = listaGarcom.Select(GarcomResponseDto.GarcomToDto);
            return Resultado.Success(listaGarcom);
        }
        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            var resultado = await _garcomRepository.ObterPorIdAsync(id);
            if (!resultado.PossuiDados)
                return resultado;

            var retorno = GarcomResponseDto.GarcomToDto((Garcom)resultado.Dados!);
            return Resultado.Success(retorno);
        }

        public async Task<Resultado> CriarAsync(CriarGarcomDto dto)
        {
            var novoGarcom = new Garcom
            {
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                Telefone = dto.Telefone
            };

            var resultado = await _garcomRepository.CriarAsync(novoGarcom);
            if (!resultado.PossuiDados)
                return resultado;

            var garcomDto = GarcomResponseDto.GarcomToDto(novoGarcom);
            return Resultado.Success(garcomDto);
        }

        public async Task<Resultado> AtualizarAsync(AtualizarGarcomDto dto)
        {
            var obterId = await _garcomRepository.ObterPorIdAsync(dto.Id);

            if (!obterId.PossuiDados)
                return obterId;

            var garcom = (Garcom)obterId.Dados!;
            var atualizarGarcom = await _garcomRepository.AtualizarAsync(garcom);
            return atualizarGarcom;
        }

        public async Task<Resultado> DeletarAsync(int id)
        {
            var obterId = await _garcomRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;

            var garcom = (Garcom)obterId.Dados!;
            var deletarGarcom = await _garcomRepository.DeletarAsync(garcom);
            return deletarGarcom;
        }
    }
}
using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Domain.Enums;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.CozinhaDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
    public class CozinhaService(ICozinhaRepository cozinhaRepository) : ICozinhaService
    {
        private readonly ICozinhaRepository _cozinhaRepository = cozinhaRepository;

        public async Task<Resultado> AtualizarAsync(int id, AtualizarCozinhaDto dto)
        {
            if (dto.StatusCozinha.HasValue &&
                !Enum.IsDefined(typeof(StatusCozinhaEnum),
                dto.StatusCozinha.Value))
                return Resultado.Falha("Tipo de Status inválido. Informe apenas 1 para ativo e 2 para inativo.");

            var obterId = await _cozinhaRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;

            var atualizar = (Cozinha)obterId.Dados!;

            if(dto.Nome is not null)
                atualizar.Nome = dto.Nome;

            if(dto.RestauranteId.HasValue)
                atualizar.RestauranteId = dto.RestauranteId.Value;

            if (dto.StatusCozinha.HasValue)
            {
                var resultadoStatus = await _cozinhaRepository.ObterStatusAtualAsync(id);
                if (!resultadoStatus.PossuiDados)
                    return resultadoStatus;

                var statusAtual = (StatusCozinha?)resultadoStatus.Dados;
                var novoStatus = (StatusCozinhaEnum)dto.StatusCozinha.Value;

                if (statusAtual == null || statusAtual.Status != novoStatus)
                {
                    atualizar.StatusCozinha.Add(new StatusCozinha
                    {
                        Status = novoStatus
                    });
                }
            }          

            var atualizarCozinha = await _cozinhaRepository.AtualizarAsync(atualizar);
            if(!atualizarCozinha.PossuiDados)
                return atualizarCozinha;

            var cozinhaDto = CozinhaResponseDto.CozinhaToDto(
                (Cozinha)atualizarCozinha.Dados!);
            return Resultado.Success(cozinhaDto);
        }

        public async Task<Resultado> CriarAsync(CriarCozinhaDto dto)
        {
            if (!Enum.IsDefined(typeof(StatusCozinhaEnum), dto.StatusCozinha))
                return Resultado.Falha("Tipo de Status inválido. Informe apenas 1 para ativo e 2 para inativo.");

            var novaCozinha = new Cozinha
            {
                Nome = dto.Nome,
                RestauranteId = dto.RestauranteId
            };

            var statusCozinha = new StatusCozinha
            {
                Status = (StatusCozinhaEnum)dto.StatusCozinha
            };

            novaCozinha.StatusCozinha.Add(statusCozinha);

            var resultado = await _cozinhaRepository.CriarAsync(novaCozinha);
            if (!resultado.PossuiDados)
                return resultado;

            var cozinhaDto = CozinhaResponseDto.CozinhaToDto(novaCozinha);
            return Resultado.Success(cozinhaDto);
        }

        public async Task<Resultado> DeletarAsync(int id)
        {
            var obterId = await _cozinhaRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;

            var cozinha = (Cozinha)obterId.Dados!;
            var deletarCozinha = await _cozinhaRepository.DeletarAsync(cozinha);
            return Resultado.Success(deletarCozinha);
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            var obterId = await _cozinhaRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;

            var retornoId = CozinhaResponseDto.CozinhaToDto((Cozinha)obterId.Dados!);
            return Resultado.Success(retornoId);
        }

        public async Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId)
        {
            var resultado = await _cozinhaRepository.ObterPorRestauranteIdAsync(restauranteId);
            if (!resultado.PossuiDados)
                return resultado;

            var listaCozinhas = (List<Cozinha>)resultado.Dados!;
            var listaDto = listaCozinhas.Select(CozinhaResponseDto.CozinhaToDto);
            return Resultado.Success(listaDto);
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _cozinhaRepository.ObterTodosAsync();
            if (!obterTodos.PossuiDados)
                return obterTodos;

            var listaCozinhas = (List<Cozinha>)obterTodos.Dados!;
            var listaDto = listaCozinhas.Select(CozinhaResponseDto.CozinhaToDto);
            return Resultado.Success(listaDto);
        }
    }
}

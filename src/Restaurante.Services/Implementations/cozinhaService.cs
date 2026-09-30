using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
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
            var obterId = await _cozinhaRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;

            var atualizar = (Cozinha)obterId.Dados!;
            atualizar.Nome = dto.Nome;
            atualizar.RestauranteId = dto.RestauranteId;
            atualizar.StatusId = dto.StatusId;

            var atualizarCozinha = await _cozinhaRepository.AtualizarAsync(atualizar);
            return atualizarCozinha;
        }

        public async Task<Resultado> CriarAsync(CriarCozinhaDto dto)
        {
            var novaCozinha = new Cozinha
            {
                Nome = dto.Nome,
                RestauranteId = dto.RestauranteId,
                StatusId = dto.StatusId
            };

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
            return deletarCozinha;
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

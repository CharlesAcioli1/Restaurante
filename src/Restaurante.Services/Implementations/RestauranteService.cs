using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.Restaurante;
using Restaurante.Services.Interfaces;
using Restaurante.Domain;

namespace Restaurante.Services.Implementations
{
    public class RestauranteService(IRestauranteRepository restauranteRepository) : IRestauranteService
    {
    private readonly IRestauranteRepository _restauranteRepository = restauranteRepository;

        public async Task<Resultado> AtualizarAsync(AtualizarRestauranteDto dto)
        {
            var obterId = await _restauranteRepository.ObterPorIdAsync(dto.Id);
            if (!obterId.PossuiDados)
                return obterId;

            var resultado = (Dom.Restaurante)obterId.Dados!;
            var atualizarRestaurante = await _restauranteRepository.AtualizarAsync(resultado);
            return atualizarRestaurante;

        }

        public async Task<Resultado> CriarAsync(CriarRestauranteDto dto)
        {
            var novoRestaurante = new Dom.Restaurante
            {
               Nome = dto.Nome,
               Cnpj = dto.Cnpj,
               Email = dto.Email,
               Telefone = dto.Telefone,
               Endereco = dto.Endereco
            };

            var criarRestaurante = await _restauranteRepository.CriarAsync(novoRestaurante);
            if (!criarRestaurante.PossuiDados)
                return criarRestaurante;

            var restaurante = RestauranteResponseDto.RestauranteToDto(novoRestaurante);
            return Resultado.Success(restaurante);
        }

        public async Task<Resultado> DeletarAsync(int id)
        {
            var obterId = await _restauranteRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;


            var restaurante = (Dom.Restaurante)obterId.Dados!;
            var deletarRestaurante = await _restauranteRepository.DeletarAsync(restaurante);
            return deletarRestaurante;
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            var obterId = await _restauranteRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;

            var retornoId = RestauranteResponseDto.RestauranteToDto((Dom.Restaurante)obterId.Dados!);
            return Resultado.Success(retornoId);
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _restauranteRepository.ObterTodosAsync();
            if (!obterTodos.PossuiDados)
                return obterTodos;

            var listaRestaurante = (List<Dom.Restaurante>)obterTodos.Dados!;
            var listaDto = listaRestaurante.Select(RestauranteResponseDto.RestauranteToDto);
            return Resultado.Success(listaRestaurante);
        }
    }    
}





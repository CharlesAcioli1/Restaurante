using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.GarcomRestauranteDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
    public class GarcomRestauranteService(IGarcomRestauranteRepository garcomRestauranteRepository,
        IGarcomRepository garcomRepository, IRestauranteRepository restauranteRepository) : IGarcomRestauranteService
    {
        private readonly IGarcomRestauranteRepository _garcomRestauranteRepository = garcomRestauranteRepository;
        private readonly IGarcomRepository _garcomRepository = garcomRepository;
        private readonly IRestauranteRepository _restauranteRepository = restauranteRepository;
        public async Task<Resultado> CriarVinculoAsync(CriarGarcomRestauranteDto dto)
        {
            var obterIdGarcom = await _garcomRepository.ObterPorIdAsync(dto.GarcomId);
            if (!obterIdGarcom.PossuiDados)
                return Resultado.Falha("Não há garçom nesta posição ou não existe!");

            var obterIdRestaurante = await _restauranteRepository.ObterPorIdAsync(dto.RestauranteId);
            if (!obterIdRestaurante.PossuiDados)
                return Resultado.Falha("Não há restaurante nesta posição ou não existe!");

            var obterVinculoExistente = await _garcomRestauranteRepository.ObterPorIdAsync(dto.GarcomId, dto.RestauranteId);
            if (obterVinculoExistente.PossuiDados)
                return Resultado.Falha("Garçom vinculado ao restaurante ou houve um erro!");

            var garcomRestaurante = new GarcomRestaurante
            {
                GarcomId = dto.GarcomId,
                RestauranteId = dto.RestauranteId
            };

            var resultado = await _garcomRestauranteRepository.CriarVinculoAsync(garcomRestaurante);
            if (!resultado.Sucesso)
                return resultado;

            var garcomRestauranteDto = GarcomRestauranteResponseDto.GarcomRestauranteToDo(garcomRestaurante);
            return Resultado.Success(garcomRestauranteDto);
        }

        public async Task<Resultado> DeletarAsync(int garcomId, int restauranteId)
        {
            var obterVinculo = await _garcomRestauranteRepository.ObterPorIdAsync(garcomId, restauranteId);
            if (!obterVinculo.PossuiDados)
                return Resultado.Falha("Não há mais vinculo ou não foi encontrado!");

            var vinculo = (GarcomRestaurante)obterVinculo.Dados!;

            var resultado = await _garcomRestauranteRepository.DeletarAsync(vinculo);
            if (!resultado.Sucesso)
                return resultado;

            return Resultado.Success(vinculo);
        }

        public async Task<Resultado> ObterPorIdAsync(int garcomId, int restauranteId)
        {
            var obterVinculo = await _garcomRestauranteRepository.ObterPorIdAsync(garcomId, restauranteId);
            if (!obterVinculo.PossuiDados || obterVinculo.Dados == null)
                return Resultado.Falha("Excluído ou não encontrado!");

            var entidade = (GarcomRestaurante)obterVinculo.Dados!;
            var dto = GarcomRestauranteResponseDto.GarcomRestauranteToDo(entidade);

            return Resultado.Success(dto);
        }
    }
}

using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.GarcomRestauranteDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
    public class GarcomRestauranteService(IGarcomRestauranteRepository garcomRestauranteRepository) : IGarcomRestauranteService
    {
        private readonly IGarcomRestauranteRepository _garcomRestauranteRepository = garcomRestauranteRepository;

        public async Task<Resultado> ObterPorData(DateTime dateUtc)
        {
            var resultado = await _garcomRestauranteRepository.ObterPorData(dateUtc);

            if(!resultado.PossuiDados)
                return resultado;

            var obterPorData = (List<GarcomRestaurante>)resultado.Dados!;
            var listaDto = obterPorData.Select(GarcomRestauranteResponseDto.GarcomRestauranteToDo).ToList();
            return Resultado.Success(listaDto);
        }

        public async Task<Resultado> ObterPorGarcomId(int id)
        {
            var obterIdGarcom = await _garcomRestauranteRepository.ObterPorGarcomId(id);
            if (!obterIdGarcom.PossuiDados)
                return obterIdGarcom;

            var obterLista = (IEnumerable<GarcomRestaurante>)obterIdGarcom.Dados!;
            var listaDto = obterLista.Select(listaGarcom => new GarcomRestauranteResponseDto
            {
                GarcomId = listaGarcom.GarcomId,
                NomeGarcom = listaGarcom.Garcom!.Nome
               
            }).ToList();
            return Resultado.Success(listaDto);
        }

        public async Task<Resultado> ObterPorRestauranteId(int id)
        {
            var obterPorIdRestaurante = await _garcomRestauranteRepository.ObterPorRestauranteId(id);
            if (!obterPorIdRestaurante.PossuiDados)
                return obterPorIdRestaurante;

            var obterLista = (IEnumerable<GarcomRestaurante>)obterPorIdRestaurante.Dados!;
            var listaDto = obterLista.Select(garcomPorRestaurante => new GarcomRestauranteResponseDto
            {
                RestauranteId = garcomPorRestaurante.RestauranteId,
                NomeRestaurante = garcomPorRestaurante.Restaurante!.Nome,
                NomeGarcom = garcomPorRestaurante.Garcom!.Nome
            }).ToList();
            return Resultado.Success(listaDto);
        }
    }
}

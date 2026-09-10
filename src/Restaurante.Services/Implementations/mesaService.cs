using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs;
using Restaurante.Services.DTOs.Mesa;
using Restaurante.Services.Interfaces;


namespace Restaurante.Services.Implementations
{
    public class MesaService(IMesaRepository mesaRepository) : IMesaService
    {
        private readonly IMesaRepository _mesaRepository = mesaRepository;

        public async Task<Resultado> AtualizarAsync(AtualizarMesaDto dto)
        {
            var resultado = await _mesaRepository.AtualizarAsync(dto);
        }

        public Task<Resultado> CriarAsync(CriarMesaDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<Resultado> DeletarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Resultado> ObterPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId)
        {
            throw new NotImplementedException();
        }

        public Task<Resultado> ObterPorStatusAsync(int statusMesa)
        {
            throw new NotImplementedException();
        }

        public Task<Resultado> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
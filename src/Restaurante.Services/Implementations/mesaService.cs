using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.Mesa;
using Restaurante.Services.Interfaces;


namespace Restaurante.Services.Implementations
{
    public class MesaService(IMesaRepository mesaRepository) : IMesaService
    {
        private readonly IMesaRepository _mesaRepository = mesaRepository;

        public async Task<Resultado> AtualizarAsync(AtualizarMesaDto dto)
        {
            var obterId = await _mesaRepository.ObterPorIdAsync(dto.Id);
            if (!obterId.PossuiDados)
                return obterId;

            var mesa = (Mesa)obterId.Dados!;
            var atualizarMesa = await _mesaRepository.AtualizarAsync(mesa);
            return atualizarMesa;
        }

        public async Task<Resultado> CriarAsync(CriarMesaDto dto)
        {
            var novaMesa = new Mesa
            {
                Numero = dto.Numero,
                StatusId = dto.StatusId,
                RestauranteId = dto.RestauranteId
            };

            var resultado = await _mesaRepository.CriarAsync(novaMesa);
            if (!resultado.PossuiDados)
                return resultado;

            var mesa = MesaResponseDto.MesaToDto(novaMesa);
            return Resultado.Success(mesa);
        }

        public async Task<Resultado> DeletarAsync(int id)
        {
            var obterId = await _mesaRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;

            var mesa = (Mesa)obterId.Dados!;
            var deletarMesa = await _mesaRepository.DeletarAsync(mesa);
            return deletarMesa;

        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            var resultado = await _mesaRepository.ObterPorIdAsync(id);
            if (!resultado.PossuiDados)
                return resultado;

            var retornoID = MesaResponseDto.MesaToDto((Mesa)resultado.Dados!);
            return Resultado.Success(retornoID);
        }

        public async Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId)
        {
            var resultado = await _mesaRepository.ObterPorRestauranteIdAsync(restauranteId);
            if (!resultado.PossuiDados)
                return resultado;

            var obterIdRestaurante = MesaResponseDto.MesaToDto((Mesa)resultado.Dados!);
            return Resultado.Success(obterIdRestaurante);
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _mesaRepository.ObterTodasAsync();
            if (!obterTodos.PossuiDados)
                return obterTodos;

            var listaMesa = (List<Mesa>)obterTodos.Dados!;
            var listaDto = listaMesa.Select(MesaResponseDto.MesaToDto);
            return Resultado.Success(listaMesa);
        }
    }
}
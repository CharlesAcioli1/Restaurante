using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.Mesa;
using Restaurante.Services.Interfaces;
using Restaurante.Domain.Validacoes;


namespace Restaurante.Services.Implementations
{
    public class MesaService(IMesaRepository mesaRepository) : IMesaService
    {
        private readonly IMesaRepository _mesaRepository = mesaRepository;

        public async Task<Resultado> AtualizarAsync(int id,AtualizarMesaDto dto)
        {
            var obterId = await _mesaRepository.ObterPorIdAsync(id);

            if (!obterId.PossuiDados)
                return obterId;

            var mesa = (Mesa)obterId.Dados!;

            if(!string.IsNullOrWhiteSpace(dto.Numero))
                mesa.Numero = dto.Numero;

            if (dto.StatusMesaId.HasValue)
            {
                StatusMesaValidacao.Validar(dto.StatusMesaId.Value);
                mesa.StatusMesaId = dto.StatusMesaId.Value;
            }

            if (dto.RestauranteID.HasValue)
                mesa.RestauranteId = dto.RestauranteID.Value;

            var atualizarMesa = await _mesaRepository.AtualizarAsync(mesa);
            if(!atualizarMesa.Sucesso)
                return atualizarMesa;

            var mesaDto = MesaResponseDto.MesaToDto(mesa);
            return Resultado.Success(mesaDto);
        }

        public async Task<Resultado> CriarAsync(CriarMesaDto dto)
        {
            StatusMesaValidacao.Validar(dto.StatusMesaId);

            var novaMesa = new Mesa
            {
                Numero = dto.Numero,
                RestauranteId = dto.RestauranteId,
                StatusMesaId = dto.StatusMesaId
            };

            var resultado = await _mesaRepository.CriarAsync(novaMesa);

            if (!resultado.Sucesso)
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

            if(!deletarMesa.Sucesso)
                return deletarMesa;
            return Resultado.Success(null);

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

            var listaMesas = (List<Mesa>)resultado.Dados!;
            var obterIdRestaurante = listaMesas.Select(MesaResponseDto.MesaToDto).ToList();

            return Resultado.Success(obterIdRestaurante);
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _mesaRepository.ObterTodasAsync();
            if (!obterTodos.PossuiDados)
                return obterTodos;

            var listaMesa = (List<Mesa>)obterTodos.Dados!;
            var listaDto = listaMesa.Select(MesaResponseDto.MesaToDto).ToList();
            return Resultado.Success(listaDto);
        }
    }
}
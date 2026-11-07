using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.Mesa;
using Restaurante.Services.Interfaces;
using Restaurante.Domain.Validacoes;
using Restaurante.Domain.Enums;


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

                mesa.StatusMesa = new StatusMesa
                {
                    Id = dto.StatusMesaId.Value,
                    StatusId = (StatusMesaEnum)dto.StatusMesaId.Value
                };
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

            var mesaExistente = await _mesaRepository.ObterTodasAsync();
            if (mesaExistente.PossuiDados)
            {
                var mesas = (IEnumerable<Mesa>)mesaExistente.Dados!;

                var mesaDuplicada = mesas.Any(m => m.Numero == dto.Numero && m.RestauranteId == dto.RestauranteId);
                if (mesaDuplicada)
                    return Resultado.Falha("Número de mesa já existente para este restaurante!");
            }

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
            if (!obterId.PossuiDados || obterId.Dados == null)
            {
                return Resultado.Falha("Posição errada, não possui dados ou é nula!");
            }

            var mesa = (Mesa)obterId.Dados!;
            var deletarMesa = await _mesaRepository.DeletarAsync(mesa);

            if(!deletarMesa.Sucesso)
                return deletarMesa;
            return Resultado.Success(null);

        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            var resultado = await _mesaRepository.ObterPorIdAsync(id);
            if (!resultado.PossuiDados || resultado.Dados == null)
                return Resultado.Falha("Posição errada, não possui dados ou é nula!");

            var mesa = (Mesa)resultado.Dados!;
            var mesaDto = MesaResponseDto.MesaToDto(mesa);

            var mesasPorId = new
            {
                nomeRestaurante = mesaDto.NomeRestaurante,
                mesa = new
                {
                    numeroMesa = mesaDto.Numero,
                    statusMesa = mesaDto.StatusMesaId
                }
            };

            return Resultado.Success(mesasPorId);
        }

        public async Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId)
        {
            var resultado = await _mesaRepository.ObterPorRestauranteIdAsync(restauranteId);
            if (!resultado.PossuiDados || resultado.Dados == null)
                return Resultado.Falha("Posição errada, não possui dados ou é nula!");

            var listaMesas = (IEnumerable<Mesa>)resultado.Dados!;
            var obterMesasPorRestaurante = listaMesas.Select(MesaResponseDto.MesaToDto).ToList();

            var mesasPorRestaurante = new
            {
                nomeRestaurante = obterMesasPorRestaurante.Select(restaurante => restaurante.NomeRestaurante).FirstOrDefault(),
                mesas = obterMesasPorRestaurante.Select(dto => new
                {
                    numero = dto.Numero,
                    statusMesaId = dto.StatusMesaId
                }).ToList()
            };


            return Resultado.Success(mesasPorRestaurante);
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _mesaRepository.ObterTodasAsync();
            if (!obterTodos.PossuiDados || obterTodos.Dados == null)
                return Resultado.Falha("Não possui dados, é nula ou não existe no banco de dados!");

            var listaMesa = (IEnumerable<Mesa>)obterTodos.Dados!;
            var listaDto = listaMesa.Select(MesaResponseDto.MesaToDto).ToList();

            var mesas = new
            {
                nomeRestaurante = listaDto.Select(restaurante => restaurante.NomeRestaurante).FirstOrDefault(),
                mesas = listaDto.Select(dto => new
                {
                    numero = dto.Numero,
                    statusMesaId = dto.StatusMesaId
                }).ToList()
            };

            return Resultado.Success(mesas);
        }

        public async Task<Resultado> ObterPorStatusAsync(int restauranteId, int statusMesaId)
        {
            var resultado = await _mesaRepository.ObterPorStatusAsync(restauranteId, statusMesaId);
            if (!resultado.PossuiDados || resultado.Dados == null)
                return Resultado.Falha("Nenhuma mesa encontrada com esse status!");

            var listaMesas = (IEnumerable<Mesa>)resultado.Dados!;
            var listaDto = listaMesas.Select(MesaResponseDto.MesaToDto).ToList();

            var mesasPorRestauranteStatus = new
            {
                nomeRestaurante = listaDto.FirstOrDefault()?.NomeRestaurante,
                mesas = listaDto.Select(dto => new
                {
                    numeroMesa = dto.Numero,
                    statusMesa = dto.StatusMesaId
                }).ToList()
            };

            return Resultado.Success(mesasPorRestauranteStatus);
        }
    }
}
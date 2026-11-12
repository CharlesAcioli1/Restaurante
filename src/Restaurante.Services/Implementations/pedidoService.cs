using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Domain.Enums;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.PedidoDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
   public class PedidoService(IPedidoRepository pedidoRepository, IMesaRepository mesaRepository) : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository = pedidoRepository;
        private readonly IMesaRepository _mesaRepository = mesaRepository;

        public async Task<Resultado> AtualizarAsync(int id, AtualizarPedidoDto dto)
        {
            var obterId = await _pedidoRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;

            var pedido = (Pedido)obterId.Dados!;

            if(pedido.StatusId == (int)(StatusPedidoEnum)2 || pedido.StatusId == (int)(StatusPedidoEnum)3)
            {
                return Resultado.Falha("O pedido ja está em preparo ou foi entregue e não pode ser alterado!");
            }

            pedido.IdMesa = dto.IdMesa;
            pedido.StatusId = dto.StatusId;

            var atualizarPedido = await _pedidoRepository.AtualizarAsync(pedido);
            return atualizarPedido;
        }

        public async Task<Resultado> CriarAsync(CriarPedidoDto dto)
        {
            var obterMesa = await _mesaRepository.ObterPorIdAsync(dto.IdMesa);
            if (!obterMesa.Sucesso)
                return Resultado.Falha("Mesa informada não existe!");

            var mesa = (Mesa)obterMesa.Dados!;

            if (mesa.StatusMesaId != (int)StatusMesaEnum.Ocupada)
                return Resultado.Falha("Não é possível criar pedido para mesa desocupada!");

            var novoPedido = new Pedido
            {
                IdMesa = dto.IdMesa,
                StatusId = dto.StatusId
            };

            var criarPedido = await _pedidoRepository.CriarAsync(novoPedido);
            if(!criarPedido.Sucesso)
                return criarPedido;

            var pedido = PedidoResponseDto.PedidoToDto(novoPedido);
            return Resultado.Success(pedido);
        }

        public async Task<Resultado> DeletarAsync(int id)
        {
            var obterId = await _pedidoRepository.ObterPorIdAsync(id);
            if (!obterId.Sucesso)
                return obterId;

            var pedido = (Pedido)obterId.Dados!;

            if(pedido.StatusId != (int)(StatusPedidoEnum)1)
            {
                return Resultado.Falha("Apenas pedidos que ainda não estão em preparo podem ser cancelados!");
            }

            var deletarPedido =  await _pedidoRepository.DeletarAsync(pedido);

            if(!deletarPedido.Sucesso)
                return deletarPedido;
            return Resultado.Success(null);
        }

        public async Task<Resultado> ObterPorDataAsync(DateTime dateUtc)
        {
            if (dateUtc == default)
                return Resultado.Falha("A data informada é inválida ou está vazia.");

            var datas = new PeriodoPedidoDto(dateUtc);

            var resultado = await _pedidoRepository.ObterPorDataAsync(datas);
            if(!resultado.PossuiDados)
                return resultado;

            var listaDataPedido = (IEnumerable<Pedido>)resultado.Dados!;
            var listaDto = listaDataPedido.Select(PedidoResponseDto.PedidoToDto).ToList();
            return Resultado.Success(listaDto);
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            var resultado = await _pedidoRepository.ObterPorIdAsync(id);
            if(!resultado.PossuiDados || resultado.Dados == null)
                return Resultado.Falha("Posição errada, não possui dados ou é nula!");

            var retornoId = PedidoResponseDto.PedidoToDto((Pedido)resultado.Dados!);
            return Resultado.Success(retornoId);
        }

        public async Task<Resultado> ObterPorIdMesaAsync(int mesaId)
        {
            var resultado = await _pedidoRepository.ObterPorMesaIdAsync(mesaId);
            if (!resultado.PossuiDados || resultado.Dados == null)
                return Resultado.Falha("Posição errada, não possui dados ou é nula!");

            var IdMesa = (IEnumerable<Pedido>)resultado.Dados!;
            var listaDto = IdMesa.Select(PedidoResponseDto.PedidoToDto).ToList();
            return Resultado.Success(listaDto);
        }

        public async Task<Resultado> ObterPorStatusIdAsync(int statusPedido)
        {
            var status = await _pedidoRepository.ObterPorStatusIdAsync(statusPedido);
            if(!status.PossuiDados || status.Dados == null)
                return Resultado.Falha("Posição errada, não possui dados ou é nula!");

            var pedido = (IEnumerable<Pedido>)status.Dados!;
            var listaDto = pedido.Select(PedidoResponseDto.PedidoToDto).ToList();
            return Resultado.Success(listaDto);
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _pedidoRepository.ObterTodasAsync();
            if(!obterTodos.PossuiDados)
                return obterTodos;

            var listaPedido = (IEnumerable<Pedido>)obterTodos.Dados!;
            var listaDto = listaPedido.Select(PedidoResponseDto.PedidoToDto).ToList();
            return Resultado.Success(listaDto);
        }
    }
}
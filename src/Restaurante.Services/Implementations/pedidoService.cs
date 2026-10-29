using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Domain.Enums;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.PedidoDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
   public class PedidoService(IPedidoRepository pedidoRepository) : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository = pedidoRepository;

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
            var novoPedido = new Pedido
            {
                IdMesa = dto.IdMesa,
                StatusId = dto.StatusId
            };

            var criarPedido = await _pedidoRepository.CriarAsync(novoPedido);
            if(!criarPedido.PossuiDados)
                return criarPedido;

            var pedido = PedidoResponseDto.PedidoToDto(novoPedido);
            return Resultado.Success(pedido);
        }

        public async Task<Resultado> DeletarAsync(int id)
        {
            var obterId = await _pedidoRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
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
            var datas = new PeriodoPedidoDto(dateUtc);

            var resultado = await _pedidoRepository.ObterPorDataAsync(datas);
            if(!resultado.PossuiDados)
                return resultado;

            var listaDataPedido = (List<Pedido>)resultado.Dados!;
            var listaDto = listaDataPedido.Select(PedidoResponseDto.PedidoToDto).ToList();
            return Resultado.Success(listaDto);
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            var resultado = await _pedidoRepository.ObterPorIdAsync(id);
            if(!resultado.PossuiDados)
                return resultado;

            var retornoId = PedidoResponseDto.PedidoToDto((Pedido)resultado.Dados!);
            return Resultado.Success(retornoId);
        }

        public async Task<Resultado> ObterPorIdMesaAsync(int mesaId)
        {
            var resultado = await _pedidoRepository.ObterPorMesaIdAsync(mesaId);
            if (!resultado.PossuiDados)
                return resultado;

            var IdMesa = (List<Pedido>)resultado.Dados!;
            var listaDto = IdMesa.Select(PedidoResponseDto.PedidoToDto).ToList();
            return Resultado.Success(listaDto);
        }

        public async Task<Resultado> ObterPorStatusIdAsync(int statusPedido)
        {
            var status = await _pedidoRepository.ObterPorStatusIdAsync(statusPedido);
            if(!status.PossuiDados)
                return status;

            var pedido = (List<Pedido>)status.Dados!;
            var listaDto = pedido.Select(PedidoResponseDto.PedidoToDto).ToList();
            return Resultado.Success(listaDto);
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _pedidoRepository.ObterTodasAsync();
            if(!obterTodos.PossuiDados)
                return obterTodos;

            var listaPedido = (List<Pedido>)obterTodos.Dados!;
            var listaDto = listaPedido.Select(PedidoResponseDto.PedidoToDto).ToList();
            return Resultado.Success(listaDto);
        }
    }
}
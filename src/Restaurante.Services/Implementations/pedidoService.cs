using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.Pedido;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
   public class PedidoService(IPedidoRepository pedidoRepository) : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository = pedidoRepository;

        public async Task<Resultado> AtualizarAsync(AtualizarPedidoDto dto)
        {
            var obterId = await _pedidoRepository.ObterPorIdAsync(dto.Id);
            if (!obterId.PossuiDados)
                return obterId;

            var pedido = (Pedido)obterId.Dados!;
            var atualizarPedido = await _pedidoRepository.AtualizarAsync(pedido);
            return atualizarPedido;
        }

        public async Task<Resultado> CriarAsync(CriarPedidoDto dto)
        {
            var novoPedido = new Pedido
            {
                IdMesa = dto.IdMesa,
                StatusId = dto.StatusId,
                DataCriacao = dto.DataCriacao
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
            var deletarPedido =  await _pedidoRepository.DeletarAsync(pedido);
            return deletarPedido;
        }

        public async Task<Resultado> ObterPorDataAsync(DateTime dateUtc)
        {
            var inicioDia = dateUtc.Date;
            var fimDia = inicioDia.AddDays(1).AddTicks(-1);

            var resultado = await _pedidoRepository.ObterPorDataAsync(dateUtc);
            if(!resultado.PossuiDados)
                return resultado;

            var listaDataPedido = (List<Pedido>)resultado.Dados!;
            var listaDto = listaDataPedido.Select(PedidoResponseDto.PedidoToDto);
            return Resultado.Success(listaDataPedido);
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

            var IdMesa = PedidoResponseDto.PedidoToDto((Pedido)resultado.Dados!);
            return Resultado.Success(IdMesa);
        }

        public async Task<Resultado> ObterPorStatusIdAsync(int statusPedido)
        {
            var status = await _pedidoRepository.ObterPorStatusIdAsync(statusPedido);
            if(!status.PossuiDados)
                return status;

            var pedido = PedidoResponseDto.PedidoToDto((Pedido)status.Dados!);
            return Resultado.Success(pedido);
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _pedidoRepository.ObterTodasAsync();
            if(!obterTodos.PossuiDados)
                return obterTodos;

            var listaPedido = (List<Pedido>)obterTodos.Dados!;
            var listaDto = listaPedido.Select(PedidoResponseDto.PedidoToDto);
            return Resultado.Success(listaPedido);
        }
    }
}
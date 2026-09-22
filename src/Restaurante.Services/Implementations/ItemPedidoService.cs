using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.ItemPedidoDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
    public class ItemPedidoService(IItemPedidoRepository itemPedidoRepository) : IItemPedidoService
    {
        private readonly IItemPedidoRepository _itemPedidoRepository = itemPedidoRepository;

        public async Task<Resultado> AtualizarAsync(ItemPedido itemPedido)
        {
            var obterId = await _itemPedidoRepository.ObterPorIdAsync(itemPedido.PedidoId, itemPedido.ItemId, itemPedido.StatusId);
            if (!obterId.PossuiDados)
                return obterId;

            var atualizar = (ItemPedido)obterId.Dados!;
            var atualizarItemPedido = await _itemPedidoRepository.AtualizarAsync(atualizar);
            return atualizarItemPedido;
        }

        public async Task<Resultado> CriarAsync(ItemPedido itemPedido)
        {
            var novoItemPedido = new ItemPedido
            {
                PedidoId = itemPedido.PedidoId,
                ItemId = itemPedido.ItemId,
                StatusId = itemPedido.StatusId,
                Descricao = itemPedido.Descricao,
                Quantidade = itemPedido.Quantidade
            };

            var resultado = await _itemPedidoRepository.CriarAsync(novoItemPedido);
            if (!resultado.PossuiDados)
                return resultado;

            var itensPedidos = ItemPedidoResponseDto.ItemPedidoToDto(novoItemPedido);
            return Resultado.Success(itensPedidos);

        }

        public async Task<Resultado> DeletarAsync(ItemPedido itemPedido)
        {
            var obterId = await _itemPedidoRepository.ObterPorIdAsync(itemPedido.PedidoId, itemPedido.ItemId, itemPedido.StatusId);
            if (!obterId.PossuiDados)
                return obterId;

            var deletar = (ItemPedido)obterId.Dados!;
            var deletarItemPedido = await _itemPedidoRepository.DeletarAsync(deletar);
            return deletarItemPedido;
        }

        public async Task<Resultado> ObterPorIdAsync(int pedidoId, int itemId, int statusId)
        {
            var obterId = await _itemPedidoRepository.ObterPorIdAsync(pedidoId, itemId, statusId);
            if (!obterId.PossuiDados)
                return obterId;

            var idItem = ItemPedidoResponseDto.ItemPedidoToDto((ItemPedido)obterId.Dados!);
            return Resultado.Success(idItem);
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _itemPedidoRepository.ObterTodosAsync();
            if (!obterTodos.PossuiDados)
                return obterTodos;

            var listaItemPedido = (List<ItemPedido>)obterTodos.Dados!;
            var lisaDto = listaItemPedido.Select(ItemPedidoResponseDto.ItemPedidoToDto);
            return Resultado.Success(listaItemPedido);
        }
    }
}

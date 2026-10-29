using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.ItemPedidoDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
    public class ItemPedidoService(IItemPedidoRepository itemPedidoRepository, IItemCardapioRepository itemCardapioRepository) : IItemPedidoService
    {
        private readonly IItemPedidoRepository _itemPedidoRepository = itemPedidoRepository;
        private readonly IItemCardapioRepository _itemCardapioRepository = itemCardapioRepository;

        public async Task<Resultado> AtualizarAsync(AtualizarItemPedidoDto dto)
        {
            var obterId = await _itemPedidoRepository.ObterPorIdAsync(dto.PedidoId, dto.ItemCardapioId, dto.StatusId);
            if (!obterId.PossuiDados)
                return obterId;

            var atualizar = (ItemPedido)obterId.Dados!;

            if (!string.IsNullOrWhiteSpace(dto.Observacao))
                atualizar.Observacao = dto.Observacao;

            if (dto.Quantidade > 0)
                atualizar.Quantidade = dto.Quantidade;

            if (dto.StatusId > 0)
                atualizar.StatusId = dto.StatusId;

            var atualizarItemPedido = await _itemPedidoRepository.AtualizarAsync(atualizar);
            return atualizarItemPedido;
        }

        public async Task<Resultado> CriarAsync(CriarItemPedidoDto dto)
        {
            var obterItemcardapio = await _itemCardapioRepository.ObterPorIdAsync(dto.PedidoId, dto.ItemCardapioId);
            if (!obterItemcardapio.PossuiDados)
                return Resultado.Falha("Este item do cardápio não existe!");

            var novoItemPedido = new ItemPedido
            {
                PedidoId = dto.PedidoId,
                ItemCardapioId = dto.ItemCardapioId,
                Observacao = dto.Observacao,
                Quantidade = dto.Quantidade
            };

            var resultado = await _itemPedidoRepository.CriarAsync(novoItemPedido);
            if (!resultado.PossuiDados)
                return resultado;

            var itensPedidos = ItemPedidoResponseDto.ItemPedidoToDto(novoItemPedido);
            return Resultado.Success(itensPedidos);
        }

        public async Task<Resultado> DeletarAsync(int pedidoId, int itemCardapioId, int statusId)
        {
            var obterId = await _itemPedidoRepository.ObterPorIdAsync(pedidoId, itemCardapioId, statusId);
            if (!obterId.PossuiDados)
                return obterId;

            var deletar = (ItemPedido)obterId.Dados!;
            var deletarItemPedido = await _itemPedidoRepository.DeletarAsync(deletar);
            return deletarItemPedido;
        }

        public async Task<Resultado> ObterPorIdAsync(int pedidoId, int itemCardapioId, int statusId)
        {
            var obterId = await _itemPedidoRepository.ObterPorIdAsync(pedidoId, itemCardapioId, statusId);
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
            var listaDto = listaItemPedido.Select(ItemPedidoResponseDto.ItemPedidoToDto).ToList();
            return Resultado.Success(listaDto);
        }
    }
}
using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.ItemCardapio;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
    public class ItemCardapioService(IItemCardapioRepository itemCardapioRepository) : IItemCardapioService
    {
        private readonly IItemCardapioRepository _itemCardapioRepository = itemCardapioRepository;

        public async Task<Resultado> AtualizarAsync(AtualizarItemCardapioDto dto)
        {
            var obterId = await _itemCardapioRepository.ObterPorIdAsync(dto.CardapioId, dto.ItemId);
            if (!obterId.PossuiDados)
                return obterId;

            var atualizar = (ItemCardapio)obterId.Dados!;
            var atualizarItemcardapio = await _itemCardapioRepository.AtualizarAsync(atualizar);
            return atualizarItemcardapio;
        }

        public async Task<Resultado> CriarAsync(CriarItemCardapioDto dto)
        {
            var novoItemcardapio = new ItemCardapio
            {
                CardapioId = dto.CardapioId,
                ItemId = dto.ItemId,
                Preco = dto.Preco
            };

            var resultado = await _itemCardapioRepository.CriarAsync(novoItemcardapio);
            if(!resultado.PossuiDados)
                return resultado;

            var itemCardapio = ItemCardapioResponseDto.ItemCardapioToDto(novoItemcardapio);
            return Resultado.Success(itemCardapio);

        }

        public async Task<Resultado> DeletarAsync(int cardapioId, int itemId)
        {
            var obterId = await _itemCardapioRepository.ObterPorIdAsync(cardapioId, itemId);
            if (!obterId.PossuiDados)
                return obterId;

            var itemCardapio = (ItemCardapio)obterId.Dados!;
            var deletarItemCardapio = await _itemCardapioRepository.DeletarAsync(itemCardapio);
            return deletarItemCardapio;

        }

        public async Task<Resultado> ObterPorIdAsync(int cardapioId, int itemId)
        {
            var obterId = await _itemCardapioRepository.ObterPorIdAsync(cardapioId, itemId);
            if (!obterId.PossuiDados)
                return obterId;

            var retornoId = ItemCardapioResponseDto.ItemCardapioToDto((ItemCardapio)obterId.Dados!);
            return Resultado.Success(retornoId);

        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _itemCardapioRepository.ObterTodosAsync();
            if (!obterTodos.PossuiDados)
                return obterTodos;

            var listaItemCardapio = (List<ItemCardapio>)obterTodos.Dados!;
            var listaDto = listaItemCardapio.Select(ItemCardapioResponseDto.ItemCardapioToDto);
            return Resultado.Success(listaItemCardapio);
        }
    }
}

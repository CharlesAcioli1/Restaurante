using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.Interfaces;
using Restaurante.Services.DTOs.ItemDto;
using Restaurante.Domain;

namespace Restaurante.Services.Implementations
{
    public class ItemService(IItemRepository itemRepository) : IItemService
    {
        private readonly IItemRepository _itemRepository = itemRepository;

        public async Task<Resultado> AtualizarAsync(AtualizarItemDto dto)
        {
            var obterId = await _itemRepository.ObterPorIdAsync(dto.Id);
            if (!obterId.PossuiDados)
                return obterId;

            var atualizar = (Item)obterId.Dados!;
            var atualizarItem = await _itemRepository.AtualizarAsync(atualizar);
            return atualizarItem;
        }

        public async Task<Resultado> CriarAsync(CriarItemDto dto)
        {
            var novoItem = new Item
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                CozinhaId = dto.CozinhaId
            };

            var resultado = await _itemRepository.CriarAsync(novoItem);
            if(!resultado.PossuiDados)
                return resultado;

            var item = ItemResponseDto.ItemToDto(novoItem);
            return Resultado.Success(item);
        }

        public async Task<Resultado> DeletarAsync(int id)
        {
            var obterId = await _itemRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;

            var item = (Item)obterId.Dados!;
            var deletarItem = await _itemRepository.DeletarAsync(item);
            return deletarItem;


        }
        public async Task<Resultado> ObterCozinhaIdAsync(int cozinhaId)
        {
            var obterId = await _itemRepository.ObterPorCozinhaId(cozinhaId);
            if (!obterId.PossuiDados)
                return obterId;

            var obterIdCozinha = ItemResponseDto.ItemToDto((Item)obterId.Dados!);
            return Resultado.Success(obterIdCozinha);
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            var obterId = await _itemRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;

            var retornoId = ItemResponseDto.ItemToDto((Item)obterId.Dados!);
            return Resultado.Success(retornoId);

        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _itemRepository.ObterTodasAsync();
            if (!obterTodos.PossuiDados)
                return obterTodos;

            var listaItem = (List<Item>)obterTodos.Dados!;
            var listaDto = listaItem.Select(ItemResponseDto.ItemToDto);
            return Resultado.Success(listaItem);

        }
    }
}

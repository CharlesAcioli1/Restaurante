using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.ItemDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IItemService itemService, ICardapioService cardapioService) : ControllerBase
    {
        private readonly IItemService _itemService = itemService;
        private readonly ICardapioService _cardapioService = cardapioService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _itemService.ObterTodosAsync();
            return Ok(resultado.Dados);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var obterId = await _itemService.ObterPorIdAsync(id);
            return Ok(obterId.Dados);
        }

        [HttpGet("{cozinhaId:int}/cozinhas")]
        public async Task<IActionResult> ObterPorCozinhaIdAsync(int cozinhaId)
        {
            var resultado = await _itemService.ObterCozinhaIdAsync(cozinhaId);
            return Ok(resultado.Dados);
        }

        [HttpGet("{cardapioId}/cardapios")]
        public async Task<IActionResult> ObterPorCardapioIdAsync(int cardapioId)
        {
            var cardapios = await _cardapioService.ObterPorIdAsync(cardapioId);
            return Ok(cardapios.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarItemDto dto)
        {
            var itens = await _itemService.CriarAsync(dto);
            if (!itens.PossuiDados)
                return BadRequest(itens);
            return Ok(itens.Dados);
        }

        [HttpPatch]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarItemDto dto)
        {
            var atualizar = await _itemService.AtualizarAsync(dto);
            return Ok(atualizar.Dados);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var deletar = await _itemService.DeletarAsync(id);
            return Ok(deletar);
        }
    }
}

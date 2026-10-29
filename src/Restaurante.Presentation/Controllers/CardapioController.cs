using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Cardapio;
using Restaurante.Services.DTOs.ItemCardapio;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController(ICardapioService cardapioService, IItemCardapioService itemCardapioService) : ControllerBase
    {
        private readonly ICardapioService _cardapioService = cardapioService;
        private readonly IItemCardapioService _itemCardapioService = itemCardapioService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _cardapioService.ObterTodosAsync();
            return Ok(resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var cardapio = await _cardapioService.ObterPorIdAsync(id);
            return Ok(cardapio.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarCardapioAsync([FromBody] CriarCardapioDto dto)
        {
            var novoCardapio = await _cardapioService.CriarCardapioAsync(dto);
            return Ok(novoCardapio.Dados);
        }

        [HttpPatch("{cardapioId}/itens{itemId}")]
        public async Task<IActionResult> AtualizarAsync(int cardapioId, int itemId, [FromBody] AtualizarItemCardapioDto dto)
        {
            if (dto.CardapioId != cardapioId || dto.ItemId != itemId)
                return BadRequest("Rota e corpo não coincidem.");

            var atualizaritemcardapio = await _itemCardapioService.AtualizarAsync(dto);

            if (!atualizaritemcardapio.PossuiDados)
                return BadRequest(atualizaritemcardapio);

            return Ok(atualizaritemcardapio);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarCardapioAsync(int id, [FromBody] AtualizarCardapioDto dto)
        {
            var atualizar = await _cardapioService.AtualizarCardapioAsync(id, dto);
            return Ok(atualizar.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var deletar = await _cardapioService.DeletarAsync(id);

            if(!deletar.Sucesso)
                return BadRequest(deletar);

            return Ok();
        }
    }
}
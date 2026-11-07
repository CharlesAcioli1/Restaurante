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

            if (!resultado.PossuiDados)
                return BadRequest(new { Error = resultado.Erro });

            return Ok(resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var cardapio = await _cardapioService.ObterPorIdAsync(id);

            if (!cardapio.PossuiDados)
                return BadRequest(new { Error = cardapio.Erro });

            return Ok(cardapio.Dados);
        }

        [HttpGet("restaurante/{restauranteId}")]
        public async Task<IActionResult> ObterPorRestauranteIdAsync(int restauranteId)
        {
            var resultado = await _cardapioService.ObterPorRestauranteIdAsync(restauranteId);

            if (!resultado.PossuiDados)
                return BadRequest(new { Error = resultado.Erro });

            return Ok(resultado.Dados);
        }

        [HttpGet("{cardapioId}/itens")]
        public async Task<IActionResult> ObterItensPorCardapioIdAsync(int cardapioId)
        {
            var resultado = await _itemCardapioService.ObterPorCardapioIdAsync(cardapioId);
            if(!resultado.PossuiDados)
                return BadRequest(new {Error = resultado.Erro});

            return Ok(resultado.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarCardapioAsync([FromBody] CriarCardapioDto dto)
        {
            var novoCardapio = await _cardapioService.CriarCardapioAsync(dto);

            if (!novoCardapio.Sucesso)
                return BadRequest(new { Error = novoCardapio.Erro });

            return Ok(novoCardapio.Dados);
        }

        [HttpPost("{cardapioId}/itens/{itemId}/preco")]
        public async Task<IActionResult> CriarPrecoAsync(int cardapioId, int itemId, [FromBody] CriarItemCardapioDto dto)
        {
            var preco = await _itemCardapioService.CriarAsync(cardapioId, itemId, dto);

            if (!preco.Sucesso)
                return BadRequest(new { Error = preco.Erro });

            return Ok(preco.Dados);
        }

        [HttpPatch("{cardapioId}/itens/{itemId}")]
        public async Task<IActionResult> AtualizarAsync(int cardapioId, int itemId, [FromBody] AtualizarItemCardapioDto dto)
        {
            var atualizaritemcardapio = await _itemCardapioService.AtualizarAsync(cardapioId, itemId, dto);

            if (!atualizaritemcardapio.Sucesso)
                return BadRequest(new { Error = atualizaritemcardapio.Erro });

            return Ok(atualizaritemcardapio.Dados);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarCardapioAsync(int id, [FromBody] AtualizarCardapioDto dto)
        {
            var atualizar = await _cardapioService.AtualizarCardapioAsync(id, dto);

            if (!atualizar.Sucesso)
                return BadRequest(new { Error = atualizar.Erro });

            return Ok(atualizar.Dados);
        }

        [HttpDelete("{cardapioId}/itens/{itemId}")]
        public async Task<IActionResult> DeletarAsync(int cardapioId, int itemId)
        {
            var deletar = await _itemCardapioService.DeletarAsync(cardapioId, itemId);

            if (!deletar.Sucesso)
                return BadRequest(new { Error = deletar.Erro });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var deletar = await _cardapioService.DeletarAsync(id);

            if (!deletar.Sucesso)
                return BadRequest(new { Error = deletar.Erro });

            return Ok();
        }
    }
}
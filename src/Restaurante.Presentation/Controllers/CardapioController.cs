using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Cardapio;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        private readonly ICardapioService _cardapioService;

        public CardapioController(ICardapioService cardapioService)
        {
            _cardapioService = cardapioService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var cardapios = await _cardapioService.ObterTodosAsync();
            return Ok(cardapios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute]int id)
        {
            var cardapios = await _cardapioService.ObterPorIdAsync(id);
            return Ok(cardapios);
        }

        [HttpPost]
        public async Task<IActionResult> CriarCardapioAsync([FromBody]CriarCardapioDto dto)
        {
            var novoCardapio = await _cardapioService.CriarCardapioAsync(dto);
            return CreatedAtAction(nameof(ObterPorIdAsync), new { id = novoCardapio.Dados }, novoCardapio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCardapioAsync([FromRoute] int id, [FromBody]AtualizarCardapioDto dto)
        {
            var atualizarDto = dto with { Id = id };

            await _cardapioService.AtualizarCardapioAsync(atualizarDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync([FromRoute]int id)
        {
            await _cardapioService.DeletarAsync(id);
            return NoContent();
        }
    }
}

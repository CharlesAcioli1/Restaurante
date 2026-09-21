using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Cardapio;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController(ICardapioService cardapioService) : ControllerBase
    {
        private readonly ICardapioService _cardapioService = cardapioService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _cardapioService.ObterTodosAsync();
            if (resultado.Erro is not null)
                return NotFound(resultado);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            await _cardapioService.ObterPorIdAsync(id);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ObterPorCardapioId(int restauranteId)
        {
            await _cardapioService.ObterPorRestauranteIdAsync(restauranteId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CriarCardapioAsync([FromBody]CriarCardapioDto dto)
        {
            var novoCardapio = await _cardapioService.CriarCardapioAsync(dto);
            return CreatedAtAction(nameof(ObterPorIdAsync), new { id = novoCardapio.Dados }, novoCardapio);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCardapioAsync([FromBody]AtualizarCardapioDto dto)
        {
            await _cardapioService.AtualizarCardapioAsync(dto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            await _cardapioService.DeletarAsync(id);
            return NoContent();
        }
    }
}

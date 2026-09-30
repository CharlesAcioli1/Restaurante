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
            return Ok(resultado.Dados);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var cardapio = await _cardapioService.ObterPorIdAsync(id);
            return Ok(cardapio.Dados);
        }

        [HttpGet("{restauranteId:int}/Restaurantes")]
        public async Task<IActionResult> ObterPorRestauranteIdAsync([FromRoute] int restauranteId)
        {
            var restaurantes = await _cardapioService.ObterPorRestauranteIdAsync(restauranteId);
            return Ok(restaurantes.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarCardapioAsync([FromBody] CriarCardapioDto dto)
        {
            var novoCardapio = await _cardapioService.CriarCardapioAsync(dto);
            return Ok(novoCardapio.Dados);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> AtualizarCardapioAsync([FromRoute] int id, [FromBody] AtualizarCardapioDto dto)
        {
            var atualizar = await _cardapioService.AtualizarCardapioAsync(id, dto);
            return Ok(atualizar.Dados);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var deletar = await _cardapioService.DeletarAsync(id);
            return Ok(deletar);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Restaurante;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController(IRestauranteService restauranteService, ICardapioService cardapioService) : ControllerBase
    {
        private readonly IRestauranteService _restauranteService = restauranteService;
        private readonly ICardapioService _cardapioService = cardapioService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _restauranteService.ObterTodosAsync();
            return Ok(resultado.Dados);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var restaurante = await _restauranteService.ObterPorIdAsync(id);
            return Ok(restaurante.Dados);
        }

        [HttpGet("{restauranteId}/cardapios")]
        public async Task<IActionResult> ObterCardapiosPorRestauranteIdAsync(int restauranteId)
        {
            var cardapios = await _cardapioService.ObterPorRestauranteIdAsync(restauranteId);
            return Ok(cardapios.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarRestauranteDto dto)
        {
            var restaurantes = await _restauranteService.CriarAsync(dto);
            return Ok(restaurantes.Dados);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAsync([FromRoute] int id, [FromBody] AtualizarRestauranteDto dto)
        {
            var atualizar = await _restauranteService.AtualizarAsync(id, dto);
            return Ok(atualizar.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var resultado = await _restauranteService.DeletarAsync(id);

            if(!resultado.Sucesso)
                return Ok(resultado);

            return Ok();
        }
    }
}

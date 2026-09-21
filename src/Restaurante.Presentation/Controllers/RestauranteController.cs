using Microsoft.AspNetCore.Mvc;
using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.Restaurante;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController(IRestauranteService restauranteService) : ControllerBase
    {
        private readonly IRestauranteService _restauranteService = restauranteService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _restauranteService.ObterTodosAsync();
            if (resultado.Erro is not null)
                return NotFound(resultado);
            return Ok(resultado);
        }
        [HttpGet]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            await _restauranteService.ObterPorIdAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarRestauranteDto dto)
        {
            var restaurantes = await _restauranteService.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorIdAsync), new { Id = restaurantes.Dados }, restaurantes);
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarRestauranteDto dto)
        {
            await _restauranteService.AtualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            await _restauranteService.DeletarAsync(id);
            return NoContent();
        }
    }
}

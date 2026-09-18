using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Restaurante;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly IRestauranteService _restauranteService;

        public RestauranteController(IRestauranteService restauranteService)
        {
            _restauranteService = restauranteService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var restaurantes =  await _restauranteService.ObterTodosAsync();
            return Ok(restaurantes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var restaurantes = await _restauranteService.ObterPorIdAsync(id);
            return Ok(restaurantes);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarRestauranteDto dto)
        {
            var restaurantes = await _restauranteService.CriarAsync(dto);
            return CreatedAtAction(nameof(CriarAsync), new { Id = restaurantes.Dados }, restaurantes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] AtualizarRestauranteDto dto)
        {
            var atualizarDtoRestaurante = dto with { Id = id };
            await _restauranteService.AtualizarAsync(atualizarDtoRestaurante);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            await _restauranteService.DeletarAsync(id);
            return NoContent();
        }
    }
}

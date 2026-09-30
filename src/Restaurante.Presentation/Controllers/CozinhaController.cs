using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.CozinhaDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CozinhaController(ICozinhaService cozinhaService) : ControllerBase
    {
        private readonly ICozinhaService _cozinhaService = cozinhaService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _cozinhaService.ObterTodosAsync();
            return Ok(resultado.Dados);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var resultado = await _cozinhaService.ObterPorIdAsync(id);
            return Ok(resultado.Dados);
        }

        [HttpGet("{restauranteId:int}/restaurantes")]
        public async Task<IActionResult> ObterPorRestauranteIdAsync(int restauranteId)
        {
            var resultado = await _cozinhaService.ObterPorRestauranteIdAsync(restauranteId);
            return Ok(resultado.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarCozinhaDto dto)
        {
            var resultado = await _cozinhaService.CriarAsync(dto);
            return Ok(resultado.Dados);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> AtualizarAsync([FromRoute] int id, [FromBody] AtualizarCozinhaDto dto)
        {
            var resultado = await _cozinhaService.AtualizarAsync(id, dto);
            return Ok(resultado.Dados);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var resultado = await _cozinhaService.DeletarAsync(id);
            return Ok(resultado);
        }
    }
}

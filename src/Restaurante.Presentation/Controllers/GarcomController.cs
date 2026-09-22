using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs;
using Restaurante.Services.DTOs.Garcom;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarcomController(IGarcomService garcomService) : ControllerBase
    {
        private readonly IGarcomService _garcomService = garcomService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _garcomService.ObterTodosAsync();
            if (resultado.Erro is not null)
                return NotFound(resultado);
            return Ok(resultado);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            await _garcomService.ObterPorIdAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CriarGarcomAsync([FromBody] CriarGarcomDto dto)
        {
            var garcons = await _garcomService.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorIdAsync), new {id = garcons.Dados}, garcons);

        }

        [HttpPut]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarGarcomDto dto)
        {
            await _garcomService.AtualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            await _garcomService.DeletarAsync(id);
            return NoContent();
        }
    }
}

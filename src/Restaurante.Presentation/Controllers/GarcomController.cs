using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs;
using Restaurante.Services.DTOs.Garcom;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarcomController : ControllerBase
    {
        private readonly IGarcomService _garcomService;

        public GarcomController(IGarcomService garcomService)
        {
            _garcomService = garcomService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var garcons = await _garcomService.ObterTodosAsync();
            return Ok(garcons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute]int id)
        {
            var garcons = await _garcomService.ObterPorIdAsync(id);
            return Ok(garcons);
        }

        [HttpPost]
        public async Task<IActionResult> CriarGarcomAsync([FromBody] CriarGarcomDto dto)
        {
            var garcons = await _garcomService.CriarAsync(dto);
            return CreatedAtAction(nameof(CriarGarcomAsync), new {id = garcons.Dados}, garcons);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAsync([FromRoute] int id, [FromBody] AtualizarGarcomDto dto)
        {
            var atualizarDtoGarcom = dto with { Id = id };
            await _garcomService.AtualizarAsync(atualizarDtoGarcom);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync([FromRoute]int id)
        {
            await _garcomService.DeletarAsync(id);
            return NoContent();
        }
    }
}

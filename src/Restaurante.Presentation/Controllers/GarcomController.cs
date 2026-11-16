using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Garcom;
using Restaurante.Services.DTOs.GarcomRestauranteDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarcomController(IGarcomService garcomService, IGarcomRestauranteService garcomRestauranteService) : ControllerBase
    {
        private readonly IGarcomService _garcomService = garcomService;
        private readonly IGarcomRestauranteService _garcomRestauranteService = garcomRestauranteService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _garcomService.ObterTodosAsync();

            if(!resultado.PossuiDados)
                return BadRequest(new { Error = resultado.Erro});

            return Ok(resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var obterId = await _garcomService.ObterPorIdAsync(id);

            if(!obterId.PossuiDados)
                return BadRequest(new { Error = obterId.Erro });

            return Ok(obterId.Dados);
        }

        [HttpPost("vinculo")]
        public async Task<IActionResult> CriarVinculo([FromBody] CriarGarcomRestauranteDto dto)
        {
            var resultado = await _garcomRestauranteService.CriarVinculoAsync(dto);
            if (!resultado.Sucesso)
                return BadRequest(new { Error = resultado.Erro });

            return Ok(resultado.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarGarcomAsync([FromBody] CriarGarcomDto dto)
        {
            var garcons = await _garcomService.CriarAsync(dto);

            if(!garcons.Sucesso)
                return BadRequest(new { Error = garcons.Erro});

            return Ok(garcons.Dados);

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] AtualizarGarcomDto dto)
        {
            var atualizar = await _garcomService.AtualizarAsync(id, dto);

            if(!atualizar.Sucesso)
                return BadRequest(new { Error = atualizar.Erro});

            return Ok(atualizar.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var deletar = await _garcomService.DeletarAsync(id);
            if(!deletar.Sucesso)
                return BadRequest(new {Error = deletar.Erro});

            return Ok();
        }

        [HttpDelete("{garcomId}/restaurante/{restauranteId}")]
        public async Task<IActionResult> DeletarVinculo(int garcomId, int restauranteId)
        {
            var resultado = await _garcomRestauranteService.DeletarAsync(garcomId, restauranteId);
            if (!resultado.PossuiDados)
                return BadRequest(new { Error = resultado.Erro });

            return Ok();
        }
    }
}

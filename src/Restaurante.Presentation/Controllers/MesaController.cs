using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Mesa;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController(IMesaService mesaService) : ControllerBase
    {
        private readonly IMesaService _mesaService = mesaService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _mesaService.ObterTodosAsync();
            if (resultado.Erro is not null)
                return NotFound(resultado);
            return Ok(resultado);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorIdAsyc(int id)
        {
            var mesas = await _mesaService.ObterPorIdAsync(id);
            return Ok(mesas);
        }

        [HttpGet("{restauranteId}")]
        public async Task<IActionResult> ObterPorRestauranteIdAsync(int restauranteId)
        {
            var mesas = await _mesaService.ObterPorRestauranteIdAsync(restauranteId);
            return Ok(mesas);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarMesaDto dto)
        {
            var mesa = await _mesaService.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorIdAsyc), new { Id = mesa.Dados }, mesa);
        }

        [HttpPatch]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarMesaDto dto)
        {
            await _mesaService.AtualizarAsync(dto);
            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            await _mesaService.DeletarAsync(id);
            return NoContent();
        }
    }
}

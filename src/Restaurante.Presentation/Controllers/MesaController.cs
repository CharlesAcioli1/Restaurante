using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Mesa;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaService _mesaService;

        public MesaController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var mesas = await _mesaService.ObterTodosAsync();
            return Ok(mesas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsyc(int id)
        {
            var mesas = await _mesaService.ObterPorIdAsync(id);
            return Ok(mesas);
        }

        [HttpGet("restaurante/{restauranteId}")]
        public async Task<IActionResult> ObterPorRestauranteIdAsync(int restauranteId)
        {
            var mesas = await _mesaService.ObterPorRestauranteIdAsync(restauranteId);
            return Ok(mesas);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarMesaDto dto)
        {
            var mesa = await _mesaService.CriarAsync(dto);
            return CreatedAtAction(nameof(CriarAsync), new { Id = mesa.Dados }, mesa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] AtualizarMesaDto dto)
        {
            var atualizarDtoMesa = dto with { Id = id };
            await _mesaService.AtualizarAsync(atualizarDtoMesa);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            await _mesaService.DeletarAsync(id);
            return NoContent();
        }
    }
}

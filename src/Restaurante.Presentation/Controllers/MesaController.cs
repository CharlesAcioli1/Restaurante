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
            return Ok(resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsyc(int id)
        {
            var mesas = await _mesaService.ObterPorIdAsync(id);
            return Ok(mesas.Dados);
        }

        [HttpGet("restaurante/{restauranteId}")]
        public async Task<IActionResult> ObterPorRestauranteIdAsync(int restauranteId)
        {
            var restaurantes = await _mesaService.ObterPorRestauranteIdAsync(restauranteId);
            return Ok(restaurantes.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarMesaDto dto)
        {
            var mesa = await _mesaService.CriarAsync(dto);
            return Ok(mesa.Dados);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] AtualizarMesaDto dto)
        {
            var mesa = await _mesaService.AtualizarAsync(id, dto);
            return Ok(mesa.Dados);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var mesa = await _mesaService.DeletarAsync(id);

            if(!mesa.Sucesso)
                return BadRequest(mesa);

            return Ok();
        }
    }
}

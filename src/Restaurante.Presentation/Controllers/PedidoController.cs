using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Pedido;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController(IPedidoService pedidoService) : ControllerBase
    {
        private readonly IPedidoService _pedidoService = pedidoService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _pedidoService.ObterTodosAsync();
            if (resultado.Erro is not null)
                return NotFound(resultado);
            return Ok(resultado);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            await _pedidoService.ObterPorIdAsync(id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody]CriarPedidoDto dto)
        {
            var pedidos = await _pedidoService.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorIdAsync), new { Id = pedidos.Dados }, pedidos);
        }

        [HttpPatch]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarPedidoDto dto)
        {
            await _pedidoService.AtualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            await _pedidoService.DeletarAsync(id);
            return NoContent();
        }
    }
}

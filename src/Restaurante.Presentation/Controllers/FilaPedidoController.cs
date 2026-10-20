using Microsoft.AspNetCore.Mvc;
using Restaurante.Domain.Compartilhar;
using Restaurante.Services.DTOs.FilaPedido;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilaPedidoController(IFilaPedidoService filaPedidoService) : ControllerBase
    {
        private readonly IFilaPedidoService _filaPedidoService = filaPedidoService;
        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var obterTodos = await _filaPedidoService.ObterTodosAsync();

            if(!obterTodos.PossuiDados)
                return BadRequest(obterTodos);

            return Ok(obterTodos.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var obterId = await _filaPedidoService.ObterPorIdAsync(id);

            if(!obterId.PossuiDados)
                return NotFound(obterId);

            return Ok(obterId.Dados);
        }

        [HttpGet("pedido/{pedidoId}")]
        public async Task<IActionResult> ObterPorPedidoId(int pedidoId)
        {
            var obterIdPedido = await _filaPedidoService.ObterPorPedidoId(pedidoId);

            if(!obterIdPedido.PossuiDados)
                return NotFound(obterIdPedido);

            return Ok(obterIdPedido.Dados);
        }

        [HttpGet("data")]
        public async Task<IActionResult> ObterPorData([FromQuery] DateTime dateUtc)
        {
            var obterData = await _filaPedidoService.ObterPorData(dateUtc);

            if (!obterData.PossuiDados)
                return Ok(obterData);

            return Ok(obterData.Dados);
        }
    }
}
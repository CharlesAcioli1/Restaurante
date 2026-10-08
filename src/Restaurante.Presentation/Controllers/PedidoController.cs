using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Pedido;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController(IPedidoService pedidoService,
        IGarcomService garcomService,
        IItemService itemService,
        IMesaService mesaService) : ControllerBase
    {
        private readonly IPedidoService _pedidoService = pedidoService;
        private readonly IGarcomService _garcomService = garcomService;
        private readonly IItemService _itemService = itemService;
        private readonly IMesaService _mesaService = mesaService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _pedidoService.ObterTodosAsync();
            return Ok(resultado.Dados);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var obterId = await _pedidoService.ObterPorIdAsync(id);
            return Ok(obterId.Dados);
        }

        [HttpGet("{itemId}/itens")]
        public async Task<IActionResult> ObterPorItemIdAsync(int itemId)
        {
            var itens = await _itemService.ObterPorIdAsync(itemId);
            return Ok(itens.Dados);
        }

        [HttpGet("{garcomId}/garcons")]
        public async Task<IActionResult> ObterPorGarcomIdAsync(int garcomId)
        {
            var garcons = await _garcomService.ObterPorIdAsync(garcomId);
            return Ok(garcons.Dados);
        }

        [HttpGet("{mesaId}")]
        public async Task<IActionResult> ObterPorMesaId(int mesaId)
        {
            var mesas = await _mesaService.ObterPorIdAsync(mesaId);
            return Ok(mesas.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarPedidoDto dto)
        {
            var pedidos = await _pedidoService.CriarAsync(dto);
            return Ok(pedidos.Dados);
        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> AtualizarAsync([FromRoute] int id, [FromBody] AtualizarPedidoDto dto)
        {
            var atualizar = await _pedidoService.AtualizarAsync(id, dto);
            return Ok(atualizar.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var deletar = await _pedidoService.DeletarAsync(id);

            if(!deletar.Sucesso)
                return Ok(deletar);

            return Ok();
        }
    }
}

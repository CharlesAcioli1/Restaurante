using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.PedidoDto;
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

            if (!resultado.PossuiDados)
                return BadRequest(new { Error = resultado.Erro });

            return Ok(resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var obterId = await _pedidoService.ObterPorIdAsync(id);

            if (!obterId.PossuiDados)
                return BadRequest(new { Error = obterId.Erro });

            return Ok(obterId.Dados);
        }

        [HttpGet("{itemId}/itens")]
        public async Task<IActionResult> ObterPorItemIdAsync(int itemId)
        {
            var itens = await _itemService.ObterPorIdAsync(itemId);

            if (!itens.PossuiDados)
                return BadRequest(new { Error = itens.Erro });

            return Ok(itens.Dados);
        }

        [HttpGet("{garcomId}/garcons")]
        public async Task<IActionResult> ObterPorGarcomIdAsync(int garcomId)
        {
            var garcons = await _garcomService.ObterPorIdAsync(garcomId);

            if (!garcons.PossuiDados)
                return BadRequest(new { Error = garcons.Erro });

            return Ok(garcons.Dados);
        }

        [HttpGet("mesa/{mesaId}")]
        public async Task<IActionResult> ObterPorMesaId(int mesaId)
        {
            var mesas = await _mesaService.ObterPorIdAsync(mesaId);

            if(!mesas.PossuiDados)
                return BadRequest(new { Error =  mesas.Erro });

            return Ok(mesas.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarPedidoDto dto)
        {
            var pedidos = await _pedidoService.CriarAsync(dto);

            if (!pedidos.Sucesso)
                return BadRequest(new {erro = pedidos.Erro});

            return Ok(pedidos.Dados);
        }

        [HttpGet("data")]
        public async Task<IActionResult> ObterPorDataAsync([FromQuery] DateTime dateUtc)
        {
            var resultado = await _pedidoService.ObterPorDataAsync(dateUtc);

            if (!resultado.Sucesso)
                return BadRequest(new { erro = resultado.Erro });

            return Ok(resultado.Dados);
        }

        [HttpGet("status/{statusId}")]
        public async Task<IActionResult> ObterPorStatusIdAsync(int statusId)
        {
            var resultado = await _pedidoService.ObterPorStatusIdAsync(statusId);

            if (!resultado.Sucesso)
                return BadRequest(new { erro = resultado.Erro });

            return Ok(resultado.Dados);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] AtualizarPedidoDto dto)
        {
            var atualizar = await _pedidoService.AtualizarAsync(id, dto);

            if(!atualizar.Sucesso)
                return BadRequest(new { Error = atualizar.Erro });

            return Ok(atualizar.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var deletar = await _pedidoService.DeletarAsync(id);

            if(!deletar.Sucesso)
                return BadRequest(new {erro = deletar.Erro});

            return Ok();
        }
    }
}

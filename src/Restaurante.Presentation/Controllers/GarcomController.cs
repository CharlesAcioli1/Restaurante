using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Garcom;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarcomController(IGarcomService garcomService,
        IItemService itemService,
        IMesaService mesaService,
        IFilaPedidoService filaPedidoService) : ControllerBase
    {
        private readonly IGarcomService _garcomService = garcomService;
        private readonly IItemService _itemService = itemService;
        private readonly IMesaService _mesaService = mesaService;
        private readonly IFilaPedidoService _filaPedidoService = filaPedidoService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _garcomService.ObterTodosAsync();
            return Ok(resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var obterId = await _garcomService.ObterPorIdAsync(id);
            return Ok(obterId.Dados);
        }

        [HttpGet("{itemId}/itens")]
        public async Task<IActionResult> ObterPorItemIDAsync(int itemId)
        {
            var itens = await _itemService.ObterPorIdAsync(itemId);
            return Ok(itens.Dados);
        }

        [HttpGet("{mesaId}/mesas")]
        public async Task<IActionResult> ObterPorMesaIdAsync(int mesaId)
        {
            var mesas = await _mesaService.ObterPorIdAsync(mesaId);
            return Ok(mesas.Dados);
        }

        [HttpGet("{filaId}/filas")]
        public async Task<IActionResult> ObterPorFilaIdAsync(int filaId)
        {
            var filas = await _filaPedidoService.ObterPorIdAsync(filaId);
            return Ok(filas.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarGarcomAsync([FromBody] CriarGarcomDto dto)
        {
            var garcons = await _garcomService.CriarAsync(dto);
            return Ok(garcons.Dados);

        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] AtualizarGarcomDto dto)
        {
            var atualizar = await _garcomService.AtualizarAsync(id, dto);
            return Ok(atualizar.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var deletar = await _garcomService.DeletarAsync(id);
            if(!deletar.Sucesso)
                return BadRequest(deletar);

            return Ok();
        }
    }
}

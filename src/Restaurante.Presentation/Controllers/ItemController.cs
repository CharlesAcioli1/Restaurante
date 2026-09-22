using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.ItemDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IItemService itemService) : ControllerBase
    {
        private readonly IItemService _itemService = itemService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _itemService.ObterTodosAsync();
            if (resultado.Erro is not null)
                return NotFound(resultado);
            return Ok(resultado);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            await _itemService.ObterPorIdAsync(id);
            return Ok();
        }

        [HttpGet("{cozinhaId}")]
        public async Task<IActionResult> ObterPorCozinhaIdAsync(int cozinhaId)
        {
            await _itemService.ObterCozinhaIdAsync(cozinhaId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarItemDto dto)
        {
            var itens = await _itemService.CriarAsync(dto);
            return CreatedAtAction(nameof(ObterPorIdAsync), new { Id = itens.Dados }, itens);
        }

        [HttpPatch]
        public async Task<IActionResult> AtualizarAsync([FromBody] AtualizarItemDto dto)
        {
            await _itemService.AtualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            await _itemService.DeletarAsync(id);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.ItemDto;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IItemService itemService, ICardapioService cardapioService) : ControllerBase
    {
        private readonly IItemService _itemService = itemService;
        private readonly ICardapioService _cardapioService = cardapioService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _itemService.ObterTodosAsync();

            if(!resultado.PossuiDados)
                return BadRequest(new { Error = resultado.Erro });

            return Ok(resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var obterId = await _itemService.ObterPorIdAsync(id);

            if(!obterId.PossuiDados)
                return BadRequest( new { Error = obterId.Erro });

            return Ok(obterId.Dados);
        }

        [HttpGet("{cardapioId}/cardapios")]
        public async Task<IActionResult> ObterPorCardapioIdAsync(int cardapioId)
        {
            var cardapios = await _cardapioService.ObterPorIdAsync(cardapioId);

            if(!cardapios.PossuiDados)
                return BadRequest(new { Error = cardapios.Erro});

            return Ok(cardapios.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarItemDto dto)
        {
            var itens = await _itemService.CriarAsync(dto);
            
            if(!itens.Sucesso)
                return BadRequest(new {Error = itens.Erro});

            return Ok(itens.Dados);
        }

        [HttpPatch ("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] AtualizarItemDto dto)
        {
            var atualizar = await _itemService.AtualizarAsync(id, dto);

            if(!atualizar.Sucesso)
                return BadRequest(new { Error = atualizar.Erro});

            return Ok(atualizar.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var deletar = await _itemService.DeletarAsync(id);

            if (!deletar.Sucesso)
                return BadRequest(deletar);

            return Ok();
        }
    }
}

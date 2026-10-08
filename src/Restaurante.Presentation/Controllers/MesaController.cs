using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Mesa;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController(IMesaService mesaService,
        IGarcomService garcomService,
        ICardapioService cardapioService,
        IItemService itemService) : ControllerBase
    {
        private readonly IMesaService _mesaService = mesaService;
        private readonly IGarcomService _garcomService = garcomService;
        private readonly ICardapioService _cardapioService = cardapioService;
        private readonly IItemService _itemService = itemService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _mesaService.ObterTodosAsync();
            return Ok(resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsyc([FromRoute] int id)
        {
            var mesas = await _mesaService.ObterPorIdAsync(id);
            return Ok(mesas.Dados);
        }

        [HttpGet("restaurante/{restauranteId}")]
        public async Task<IActionResult> ObterPorRestauranteIdAsync([FromRoute] int restauranteId)
        {
            var restaurantes = await _mesaService.ObterPorRestauranteIdAsync(restauranteId);
            return Ok(restaurantes.Dados);
        }

        [HttpGet("{garcomId}/garcons")]
        public async Task<IActionResult> ObterGarcomPorIdAsync([FromRoute] int garcomId)
        {
            var garcons = await _garcomService.ObterPorIdAsync(garcomId);
            return Ok(garcons.Dados);
        }

        [HttpGet("{cardapioId}/cardapios")]
        public async Task<IActionResult> ObterPorCardapioIdAsync([FromRoute] int cardapioId)
        {
            var cardapios = await _cardapioService.ObterPorIdAsync(cardapioId);
            return Ok(cardapios.Dados);
        }

        [HttpGet("{itemId}/itens")]
        public async Task<IActionResult> ObterPorItemIDAsync([FromRoute] int itemId)
        {
            var itens = await _itemService.ObterPorIdAsync(itemId);
            return Ok(itens.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarMesaDto dto)
        {
            var mesa = await _mesaService.CriarAsync(dto);
            return Ok(mesa.Dados);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAsync([FromRoute] int id, [FromBody] AtualizarMesaDto dto)
        {
            var mesa = await _mesaService.AtualizarAsync(id, dto);
            return Ok(mesa.Dados);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var mesa = await _mesaService.DeletarAsync(id);

            if(!mesa.Sucesso)
                return Ok(mesa);

            return Ok();
        }
    }
}

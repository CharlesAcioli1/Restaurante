using Microsoft.AspNetCore.Mvc;
using Restaurante.Services.DTOs.Restaurante;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController(IRestauranteService restauranteService, ICardapioService cardapioService,
        IMesaService mesaService, IGarcomRestauranteService garcomRestauranteService, IItemCardapioService itemCardapioService) : ControllerBase
    {
        private readonly IRestauranteService _restauranteService = restauranteService;
        private readonly ICardapioService _cardapioService = cardapioService;
        private readonly IMesaService _mesaService = mesaService;
        private readonly IItemCardapioService _itemCardapioService = itemCardapioService;
        private readonly IGarcomRestauranteService _garcomRestauranteService = garcomRestauranteService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _restauranteService.ObterTodosAsync();
            return Ok(resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync(int id)
        {
            var restaurante = await _restauranteService.ObterPorIdAsync(id);
            return Ok(restaurante.Dados);
        }

        [HttpGet("{restauranteId}/cardapios")]
        public async Task<IActionResult> ObterCardapiosPorRestauranteIdAsync(int restauranteId)
        {
            var cardapios = await _cardapioService.ObterPorRestauranteIdAsync(restauranteId);
            return Ok(cardapios.Dados);
        }

        [HttpGet("{restauranteId}/mesas")]
        public async Task<IActionResult> ObterMesasPorRestauranteIdAsync(int restauranteId)
        {
            var mesasRestaurante = await _mesaService.ObterPorRestauranteIdAsync(restauranteId);

            if (!mesasRestaurante.Sucesso)
                return BadRequest(mesasRestaurante.Erro);

            return Ok(mesasRestaurante.Dados);
        }

        [HttpGet("cardapio/{cardapioId}")]
        public async Task<IActionResult> ObterPorCardapioIdAsync(int cardapioId)
        {
            var obterIdCardapio = await _itemCardapioService.ObterPorCardapioIdAsync(cardapioId);

            if (!obterIdCardapio.Sucesso)
                return BadRequest(obterIdCardapio.Erro);

            return Ok(obterIdCardapio.Dados);
        }

        [HttpGet("{restauranteId}/garcons")]
        public async Task<IActionResult> ObterGarconsPorRestaurante(int restauranteId)
        {
            var garcomRestaurante = await _garcomRestauranteService.ObterPorRestauranteId(restauranteId);

            if (!garcomRestaurante.Sucesso)
                return BadRequest(garcomRestaurante.Erro);

            return Ok(garcomRestaurante.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarRestauranteDto dto)
        {
            var restaurantes = await _restauranteService.CriarAsync(dto);
            return Ok(restaurantes.Dados);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] AtualizarRestauranteDto dto)
        {
            var atualizar = await _restauranteService.AtualizarAsync(id, dto);
            return Ok(atualizar.Dados);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var resultado = await _restauranteService.DeletarAsync(id);

            if (!resultado.Sucesso)
                return BadRequest(resultado);

            return Ok();
        }
    }
}

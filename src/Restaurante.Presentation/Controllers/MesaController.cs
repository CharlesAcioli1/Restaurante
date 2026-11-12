using Microsoft.AspNetCore.Mvc;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.GarcomMesaDto;
using Restaurante.Services.DTOs.Mesa;
using Restaurante.Services.Interfaces;

namespace Restaurante.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController(IMesaService mesaService, IGarcomMesaService garcomMesaService) : ControllerBase
    {
        private readonly IMesaService _mesaService = mesaService;
        private readonly IGarcomMesaService _garcomMesaService = garcomMesaService;

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            var resultado = await _mesaService.ObterTodosAsync();

            if (!resultado.PossuiDados)
                return BadRequest(new { Error = resultado.Erro });

            return Ok(resultado.Dados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsyc(int id)
        {
            var mesas = await _mesaService.ObterPorIdAsync(id);

            if (!mesas.PossuiDados)
                return BadRequest(new { Error = mesas.Erro });

            return Ok(mesas.Dados);
        }

        [HttpGet("restaurante/{restauranteId}/status/{statusMesaId}")]
        public async Task<IActionResult> ObterPorStatusAsync(int restauranteId, int statusMesaId)
        {
            var resultado = await _mesaService.ObterPorStatusAsync(restauranteId, statusMesaId);

            if (!resultado.Sucesso)
                return BadRequest(new { Error = resultado.Erro });

            return Ok(resultado.Dados);
        }

        [HttpGet("restaurante/{restauranteId}")]
        public async Task<IActionResult> ObterPorRestauranteIdAsync(int restauranteId)
        {
            var restaurantes = await _mesaService.ObterPorRestauranteIdAsync(restauranteId);

            if (!restaurantes.PossuiDados)
                return BadRequest(new { Error = restaurantes.Erro });

            return Ok(restaurantes.Dados);
        }

        [HttpGet("mesa/{id}/garcom")]
        public async Task<IActionResult> ObterPorIdMesaAsync(int id)
        {
            var resultado = await _garcomMesaService.ObterPorIdMesa(id);

            if (!resultado.Sucesso)
                return BadRequest(new { Error = resultado.Erro });

            return Ok(resultado.Dados);
        }

        [HttpGet("garcom/{id}")]
        public async Task<IActionResult> ObterPorIdGarcomAsync(int id)
        {
            var resultado = await _garcomMesaService.ObterPorIdGarcom(id);

            if (!resultado.Sucesso)
                return BadRequest(new { Error = resultado.Erro });

            return Ok(resultado.Dados);
        }

        [HttpPost ("abrir_mesa/{mesaId}/garcom/{garcomId}")]
        public async Task<IActionResult> AbrirMesaAsync(int mesaId, int garcomId)
        {
            var abrirMesa = await _garcomMesaService.AbrirMesaAsync(mesaId, garcomId);
            if(!abrirMesa.Sucesso)
                return BadRequest( new {Error  = abrirMesa.Erro });

            return Ok(abrirMesa.Dados);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] CriarMesaDto dto)
        {
            var mesa = await _mesaService.CriarAsync(dto);

            if (!mesa.Sucesso)
                return BadRequest(new { erro = mesa.Erro });

            return Ok(mesa.Dados);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarAsync(int id, [FromBody] AtualizarMesaDto dto)
        {
            var mesa = await _mesaService.AtualizarAsync(id, dto);

            if (!mesa.Sucesso)
                return BadRequest(new { Error = mesa.Erro });

            return Ok(mesa.Dados);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarAsync(int id)
        {
            var mesa = await _mesaService.DeletarAsync(id);

            if (!mesa.Sucesso)
                return BadRequest(new { erro = mesa.Erro });

            return Ok();
        }

        [HttpDelete("fechar_mesa/{mesaId}/garcom/{garcomId}")]
        public async Task<IActionResult> FecharMesaAsync(int mesaId, int garcomId)
        {
            var fecharMesa = await _garcomMesaService.FecharMesaAsync(mesaId, garcomId);

            if(!fecharMesa.Sucesso)
                return BadRequest(new {Error = fecharMesa.Erro});

            return Ok(fecharMesa.Dados);
        }
    }
}

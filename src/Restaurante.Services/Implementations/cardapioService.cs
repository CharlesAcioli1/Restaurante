using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.Cardapio;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
    public class CardapioService(ICardapioRepository cardapioRepository) : ICardapioService
    {
        private readonly ICardapioRepository _cardapioRepository = cardapioRepository;

        public async Task<Resultado> ObterTodosAsync()
        {
            var resultado = await _cardapioRepository.ObterTodosAsync();

            if (!resultado.PossuiDados)
                return resultado;

            var listaCardapio = (List<Cardapio>)resultado.Dados!;

            var listaDto = listaCardapio.Select(CardapioResponseDto.CardapioToDto);

            return Resultado.Success(listaDto);
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            var resultado = await _cardapioRepository.ObterPorIdAsync(id);

            if (!resultado.PossuiDados)
                return resultado;

            var retorno = CardapioResponseDto.CardapioToDto((Cardapio)resultado.Dados!);

            return Resultado.Success(retorno);
        }

        public async Task<Resultado> ObterPorRestauranteIdAsync(int restauranteId)
        {
            var resultado = await _cardapioRepository.ObterPorRestauranteIdAsync(restauranteId);

            if (!resultado.PossuiDados)
                return resultado;

            var retorno = CardapioResponseDto.CardapioToDto((Cardapio)resultado.Dados!);

            return Resultado.Success(retorno);
        }

        public async Task<Resultado> CriarCardapioAsync(CriarCardapioDto dto)
        {
            var novoCardapio = new Cardapio
            {
                Nome = dto.Nome,
                RestauranteId = dto.RestauranteId
            };

            var resultado = await _cardapioRepository.CriarCardapioAsync(novoCardapio);

            if (!resultado.PossuiDados)
                return resultado;

            var cardapioDto = CardapioResponseDto.CardapioToDto(novoCardapio);

            return Resultado.Success(cardapioDto);
        }

        public async Task<Resultado> DeletarAsync(int id)
        {
            var resultadoBusca = await _cardapioRepository.ObterPorIdAsync(id);

            if (!resultadoBusca.PossuiDados)
                return resultadoBusca;

            var cardapio = (Cardapio)resultadoBusca.Dados!;

            var resultadoDeletar = await _cardapioRepository.DeletarAsync(cardapio);

            return resultadoDeletar;
        }

        public async Task<Resultado> AtualizarCardapioAsync(AtualizarCardapioDto dto)
        {
            var resultadoBusca = await _cardapioRepository.ObterPorIdAsync(dto.Id);

            if (!resultadoBusca.PossuiDados)
                return resultadoBusca;

            var cardapio = (Cardapio)resultadoBusca.Dados!;

            var resultadoAtualizar = await _cardapioRepository.AtualizarCardapioAsync(cardapio);

            return resultadoAtualizar;
        }
    }
}
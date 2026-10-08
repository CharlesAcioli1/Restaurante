using Restaurante.Domain;
using Restaurante.Domain.Compartilhar;
using Restaurante.Infrastructure.Repositories.Interfaces;
using Restaurante.Services.DTOs.FilaPedido;
using Restaurante.Services.Interfaces;

namespace Restaurante.Services.Implementations
{
    public class FilaPedidoService(IFilaPedidoRepository filaPedidoRepository) : IFilaPedidoService
    {
        private readonly IFilaPedidoRepository _filaPedidoRepository = filaPedidoRepository;

        public async Task<Resultado> ObterPorData(DateTime dateUtc)
        {
            var obterData = await _filaPedidoRepository.ObterPorData(dateUtc);
            if (!obterData.PossuiDados)
                return obterData;

            var retorno = FilaPedidoResponseDto.FilaPedidoToDo((FilaPedido)obterData.Dados!);
            return Resultado.Success(retorno);
        }

        public async Task<Resultado> ObterPorIdAsync(int id)
        {
            var obterId = await _filaPedidoRepository.ObterPorIdAsync(id);
            if (!obterId.PossuiDados)
                return obterId;

            var retorno = FilaPedidoResponseDto.FilaPedidoToDo((FilaPedido)obterId.Dados!);
            return Resultado.Success(retorno);
        }

        public async Task<Resultado> ObterPorPedidoId(int id)
        {
            var obterId = await _filaPedidoRepository.ObterPorPedidoId(id);
            if (!obterId.PossuiDados)
                return obterId;

            var retorno = FilaPedidoResponseDto.FilaPedidoToDo((FilaPedido)obterId.Dados!);
            return Resultado.Success(retorno);
        }

        public async Task<Resultado> ObterTodosAsync()
        {
            var obterTodos = await _filaPedidoRepository.ObterTodosAsync();
            if (!obterTodos.PossuiDados)
                return obterTodos;

            var retorno = (List<FilaPedido>)obterTodos.Dados!;
            var listaDto = retorno.Select(FilaPedidoResponseDto.FilaPedidoToDo);
            return Resultado.Success(listaDto);
        }
    }
}

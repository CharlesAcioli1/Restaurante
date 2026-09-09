using Dom = Restaurante.Domain;
using Restaurante.Domain.Compartilhar;

namespace Restaurante.Infrastructure.Repositories.Interfaces
{
    public interface IFilaPedidoRepository
    {
        Task<Resultado> ObterPosicaoAsync(int id);
        Task<Resultado> ObterPrioridadeAsync(string prioridade);
        Task<Resultado> ObterPorIdAsync(int id);
        Task<Resultado> ObterPorPedidoId(int id);
        Task<Resultado> ObterPorData(DateTime dateUtc);
    }
}

/*OBS(PARA LEMBRAR):
 * Posição (Ordem Sequencial)
Objetivo: Controlar a fila no modelo FIFO (First In, First Out — o primeiro que entra é o primeiro que sai).

Por que precisamos: O DataCriacao (DateTime) indica a hora exata em que o pedido foi feito, mas consultar
ordenando por data em filas dinâmicas pode ser custoso e não reflete reorganizações operacionais.

Na prática: A Posição determina a sequência exata de preparo na cozinha (ex: Posição 1, 2, 3).
Quando o pedido da posição 1 é concluído e sai da fila, o sistema reordena ou decrementa a posição dos
próximos pedidos para manter o fluxo organizado nos monitores da cozinha (KDS).

* Prioridade (Furar Fila por Regra de Negócio):
* Motivo -> Se for apenas uma bata frita, um idoso, uma pessoa com glicemia baixa, entre outros,
* Este item foi mantido para casos de necessidades ou pedidos que não exigem tanto tempo de preparo.
* Exemplo: Uma porção de bata frita ou porções pequenas.
*/
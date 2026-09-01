namespace Restaurante.Domain;

/*
 * ===========================
 * ESTRUTURA E TIPO DE CLASSE:
 * ===========================
 * Usamos 'public class' simples aqui.
 * 
 * POR QUE NÃO USAR OUTROS MODIFICADORES NESTE MOMENTO?
 * - 'sealed class': Impede que a classe seja herdada. Usado em Services ou DTOs para
 *   segurança e otimização de performance. Não usamos aqui porque entidades de 
 *   domínio podem precisar de herança no futuro (ex: PedidoPresencial : Pedido).
 *   
 * - 'abstract class': Classe incompleta que não pode ser instanciada diretamente. 
 *   Usada como base para outras. Não usamos aqui porque precisamos criar o 
 *   objeto 'Pedido' diretamente na memória.
 *   
 * - 'partial class': Permite dividir uma classe em múltiplos arquivos. Usado por 
 *   geradores de código ou sistemas gigantes. Desnecessário e desencorajado 
 *   para entidades simples de domínio.
 * ============================================================================
 */

/*
 * =============================
 * MODIFICADOR DE CLASSE: sealed
 * =============================
 * USAMOS 'sealed' AQUI POR QUÊ?
 * Na regra de negócio, a entidade 'Pedido' é concreta e final. Ela não foi feita 
 * para ser herdada por subclasses (ex: PedidoOnline, PedidoPresencial).
 * O uso de 'sealed' previne extensões indevidas da classe e permite otimizações 
 * pelo compilador da plataforma .NET.
 */
public sealed class Pedido
{
    public int Id { get; set; }
    public int IdMesa { get; set; }
    public int StatusId { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    
    public Mesa? Mesa { get; set; }
    public StatusPedido? Status { get; set; }
}
namespace Restaurante.Domain;

public class StatusMesa
{
    //Livre = 1,
    //Ocupada = 2,
    //Reservada = 3,
    //Manutencao = 4

    public int Id { get; set; }
    public string Descricao { get; set; } = default!;
    public DateTime DataHora { get; set; } = DateTime.UtcNow;
    //OBS: O atributo "Manutenção", foi pensando em questão da área da mesa.
    //Exemplo: Vazamento de teto, manutenção ar condicionado, entre outros.
}
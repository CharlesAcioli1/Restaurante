namespace Restaurante.Domain;

public class StatusCozinha
{
    //Ativa = 1,
    //Inativa = 2,
    //Manutencao = 3

    public int Id { get; set; }
    public string Descricao { get; set; } = default!;
    public DateTime DataHora { get; set; } = DateTime.UtcNow;

}
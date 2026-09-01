namespace Restaurante.Domain;

public class StatusGarcom
{
    //Aiivo = 1,
    //Descanso = 2,
    //Inativo = 3

    public int Id { get; set; }
    public string Descricao { get; set; } = default!;
    public DateTime DataHora { get; set; } = DateTime.UtcNow;
}
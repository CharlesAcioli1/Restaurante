using Restaurante.Domain.Enums;
namespace Restaurante.Domain;

public class StatusCozinha
{
    public int Id { get; set; }
    public int CozinhaId { get; set; }
    public StatusCozinhaEnum Status { get; set; }
    public DateTime DataHora { get; set; } = DateTime.UtcNow;

    public Cozinha? Cozinha { get; set; }

}
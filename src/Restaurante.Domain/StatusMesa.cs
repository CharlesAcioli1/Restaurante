using Restaurante.Domain.Enums;

namespace Restaurante.Domain;

public class StatusMesa
{
    public int Id { get; set; }
    public StatusMesaEnum StatusId { get; set; }
}
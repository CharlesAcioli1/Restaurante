using Dom = Restaurante.Domain;
namespace Restaurante.Services.DTOs.GarcomMesaDto;

public sealed record GarcomMesaResponseDto
{
    public int GarcomId { get; init; }
    public int MesaId { get; init; }

    public static GarcomMesaResponseDto GarcomMesaToDo(Dom.GarcomMesa garcomMesa)
        => new()
        {
            GarcomId = garcomMesa.GarcomId,
            MesaId = garcomMesa.MesaId
        };
}

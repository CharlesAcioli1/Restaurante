using Restaurante.Domain.Enums;
using Dom = Restaurante.Domain;
namespace Restaurante.Services.DTOs.GarcomMesaDto;

public sealed record GarcomMesaResponseDto
{
    public int GarcomId { get; init; }
    public int MesaId { get; init; }
    public string NomeRestaurante { get; init; } = default!;
    public string StatusMesa { get; init; } = default!;

    public static GarcomMesaResponseDto GarcomMesaToDo(Dom.GarcomMesa garcomMesa)
        => new()
        {
            GarcomId = garcomMesa.GarcomId,
            MesaId = garcomMesa.MesaId,
            NomeRestaurante = garcomMesa.Mesa?.Restaurante?.Nome ?? "Restaurante Não encontrado!",
            StatusMesa = garcomMesa.Mesa != null
                ? ((StatusMesaEnum)garcomMesa.Mesa.StatusMesaId).ToString()
                : "Status Não encontrado!"
        };
}
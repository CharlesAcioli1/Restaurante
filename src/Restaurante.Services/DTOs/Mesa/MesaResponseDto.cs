using Dom = Restaurante.Domain;
namespace Restaurante.Services.DTOs.Mesa;

public sealed record MesaResponseDto

{
    public int Id { get; init; }
    public int? StatusId { get; init; }
    public string Numero { get; init; } = default!;
    public int RestauranteId { get; init; }

    public static MesaResponseDto MesaToDto(Dom.Mesa mesa)
        => new()
        {
            Id = mesa.Id,
            Numero = mesa.Numero,
            RestauranteId = mesa.RestauranteId,
            StatusId = mesa.StatusId
        };
}
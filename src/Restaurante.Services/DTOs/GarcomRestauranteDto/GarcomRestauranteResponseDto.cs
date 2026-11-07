using Restaurante.Domain;

namespace Restaurante.Services.DTOs.GarcomRestauranteDto;

public sealed record GarcomRestauranteResponseDto
{
    public int GarcomId { get; init; }
    public int RestauranteId { get; init; }
    public string NomeGarcom {  get; init; } = default!;
    public string NomeRestaurante { get; init; } = default!;
    public DateTime DataInicio { get; init; } = DateTime.UtcNow;

    public static GarcomRestauranteResponseDto GarcomRestauranteToDo(GarcomRestaurante garcomRestaurante)
        => new()
        {
            GarcomId = garcomRestaurante.GarcomId,
            RestauranteId = garcomRestaurante.RestauranteId,
            NomeGarcom = garcomRestaurante.Garcom!.Nome,
            NomeRestaurante = garcomRestaurante.Restaurante!.Nome,
            DataInicio = garcomRestaurante.DataInicio
        };
}

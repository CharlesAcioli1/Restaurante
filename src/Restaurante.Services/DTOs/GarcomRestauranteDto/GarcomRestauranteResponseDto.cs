using Restaurante.Domain;

namespace Restaurante.Services.DTOs.GarcomRestauranteDto;

public sealed record GarcomRestauranteResponseDto
{
    public int GarcomId { get; init; }
    public int RestauranteId { get; init; }
    public DateTime DataInicio { get; init; } = DateTime.UtcNow;

    public static GarcomRestauranteResponseDto GarcomRestauranteToDo(GarcomRestaurante garcomRestaurante)
        => new()
        {
            GarcomId = garcomRestaurante.GarcomId,
            RestauranteId = garcomRestaurante.RestauranteId,
            DataInicio = garcomRestaurante.DataInicio
        };
}

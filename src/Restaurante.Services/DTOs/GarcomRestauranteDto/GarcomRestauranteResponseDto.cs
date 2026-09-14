namespace Restaurante.Services.DTOs.GarcomRestauranteDto
{
    public class GarcomRestauranteResponseDto
    {
        public int GarcomId { get; init; }
        public int RestauranteId { get; init; }
        public int StatusId { get; init; }
        public DateTime DataInicio { get; init; } = DateTime.UtcNow;
    }
}

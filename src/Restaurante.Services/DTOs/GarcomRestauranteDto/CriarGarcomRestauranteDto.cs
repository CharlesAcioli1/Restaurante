namespace Restaurante.Services.DTOs.GarcomRestauranteDto
{
    public sealed record CriarGarcomRestauranteDto
    {
        public int GarcomId { get; init; }
        public int RestauranteId { get; init; }
    }
}

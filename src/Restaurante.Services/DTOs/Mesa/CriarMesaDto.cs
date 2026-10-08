namespace Restaurante.Services.DTOs.Mesa;

public sealed record CriarMesaDto
{
    public string Numero { get; init; } = default!;
    public int RestauranteId { get; init; }
    public int? StatusId { get; init; }
}
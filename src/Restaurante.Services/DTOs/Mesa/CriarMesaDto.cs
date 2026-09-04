namespace Restaurante.Services.DTOs.Mesa;

public sealed record CriarMesaDto
{
    public int Numero {  get; init; }
    public int StatusId { get; init; }
    public int RestauranteId { get; init; }
}
namespace Restaurante.Services.DTOs.Cardapio;

public sealed record CriarCardapioDto
{
    public string Nome { get; init; } = string.Empty;
    public int RestauranteId { get; init; }
}
namespace Restaurante.Services.DTOs.Cardapio;

public sealed record CriarCardapioDto
{
    public string Nome { get; init; } = default!;
    public int RestauranteId { get; init; }
}
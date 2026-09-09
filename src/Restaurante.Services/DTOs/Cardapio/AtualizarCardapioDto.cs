namespace Restaurante.Services.DTOs.Cardapio;

public sealed record AtualizarCardapioDto
{
    public string? Nome { get; init; }
    public int RestauranteId { get; init; }
}
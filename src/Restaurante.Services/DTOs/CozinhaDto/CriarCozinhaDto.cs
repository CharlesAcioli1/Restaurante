namespace Restaurante.Services.DTOs.CozinhaDto;

public sealed record CriarCozinhaDto
{
    public string Nome { get; init; } = default!;
    public int RestauranteId { get; init; }
    public int StatusId { get; init; }
}

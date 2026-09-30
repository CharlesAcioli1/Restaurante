using Restaurante.Domain;

namespace Restaurante.Services.DTOs.CozinhaDto;

public sealed record CozinhaResponseDto
{
    public int Id { get; init; }
    public int RestauranteId { get; init; }
    public int StatusId { get; init; }
    public string Nome { get; init; } = default!;

    public static CozinhaResponseDto CozinhaToDto(Cozinha cozinha)
        => new()
        {
            Id = cozinha.Id,
            RestauranteId = cozinha.RestauranteId,
            StatusId = cozinha.StatusId,
            Nome = cozinha.Nome
        };
}

using Restaurante.Domain;

namespace Restaurante.Services.DTOs.CozinhaDto;

public sealed record CozinhaResponseDto
{
    public int Id { get; init; }
    public int RestauranteId { get; init; }
    public string Nome { get; init; } = default!;
    public int StatusCozinha { get; init; }

    public static CozinhaResponseDto CozinhaToDto(Cozinha cozinha)
        => new()
        {
            Id = cozinha.Id,
            RestauranteId = cozinha.RestauranteId,
            Nome = cozinha.Nome,
            StatusCozinha = cozinha.StatusCozinha
                .OrderByDescending(sc => sc.DataHora)
                .Select(sc => (int)sc.Status)
                .FirstOrDefault()
        };
}

using Restaurante.Domain.Enums;

namespace Restaurante.Services.DTOs.CozinhaDto;

public sealed record AtualizarCozinhaResponseDto
{
    public int Id { get; init; }
    public int RestauranteId { get; init; }
    public string Nome { get; init; } = default!;
    public StatusCozinhaEnum Status { get; init; }
}
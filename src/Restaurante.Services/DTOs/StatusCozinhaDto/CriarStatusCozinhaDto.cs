using Restaurante.Domain.Enums;

namespace Restaurante.Services.DTOs.StatusCozinhaDto;

public sealed record CriarStatusCozinhaDto
{
    public StatusCozinhaEnum Status { get; init; }
}
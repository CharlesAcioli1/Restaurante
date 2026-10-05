using Restaurante.Domain;
using Restaurante.Domain.Enums;

namespace Restaurante.Services.DTOs.StatusCozinhaDto;

public sealed record StatusCozinhaResponseDto
{
    public int Id { get; init; }
    public StatusCozinhaEnum Status { get; init; }
    public DateTime DataHora { get; init; }

    public static StatusCozinhaResponseDto StatusCozinhaToDto(
        StatusCozinha statusCozinha)
        => new()
        {
            Id = statusCozinha.Id,
            Status = statusCozinha.Status,
            DataHora = statusCozinha.DataHora
        };
}
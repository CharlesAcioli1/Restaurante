using Dom = Restaurante.Domain;
namespace Restaurante.Services.DTOs.Garcom;
public sealed record GarcomResponseDto
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public string Cpf { get; init; } = string.Empty;
    public string? Telefone { get; init; } = string.Empty;

    public static GarcomResponseDto GarcomToDto(Dom.Garcom garcom)
        => new()
        { Id = garcom.Id,
            Nome = garcom.Nome,
            Cpf = garcom.Cpf,
            Telefone = garcom.Telefone
        };
}
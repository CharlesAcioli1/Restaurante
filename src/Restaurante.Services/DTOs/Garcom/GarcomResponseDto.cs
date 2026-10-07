using Dom = Restaurante.Domain;
namespace Restaurante.Services.DTOs.Garcom;
public sealed record GarcomResponseDto
{
    public int Id { get; init; }
    public string Nome { get; init; } = default!;
    public string Cpf { get; init; } = default!;
    public string? Telefone { get; init; }

    public static GarcomResponseDto GarcomToDto(Dom.Garcom garcom)
        => new()
        { 
            Id = garcom.Id,
            Nome = garcom.Nome,
            Cpf = garcom.Cpf,
            Telefone = garcom.Telefone
        };
}
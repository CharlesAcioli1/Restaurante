using Dom = Restaurante.Domain;
namespace Restaurante.Services.DTOs.Restaurante;

public sealed record RestauranteResponseDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Cnpj { get; init; }
    public string? Email { get; init; }
    public string? Endereco { get; init; }
    public string? Telefone { get; init; }

    public static RestauranteResponseDto RestauranteToDto(Dom.Restaurante restaurante)
        => new()
        {
            Id = restaurante.Id,
            Nome = restaurante.Nome,
            Cnpj = restaurante.Cnpj,
            Email = restaurante.Email,
            Endereco = restaurante.Endereco,
            Telefone = restaurante.Telefone
        };
}
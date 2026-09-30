namespace Restaurante.Services.DTOs.Restaurante;

public sealed record CriarRestauranteDto
{
    public string Nome { get; init; } = default!;
    public string Cnpj { get; init; } = default!;
    public string Email { get; init; } = default!;
    public string Endereco {  get; init; } = default!;
    public string Telefone { get; init; } = default!;
}
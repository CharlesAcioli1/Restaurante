namespace Restaurante.Services.DTOs.Restaurante;

public sealed record CriarRestauranteDto
{
    public string Nome { get; init; } = string.Empty;
    public string Cnpj {  get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Endereco {  get; init; } = string.Empty;
    public string Telefone { get; init; } = string.Empty;
}
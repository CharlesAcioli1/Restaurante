namespace Restaurante.Services.DTOs.Restaurante;

public sealed record AtualizarRestauranteDto
{
    public int Id { get; init; }
    public string? Nome { get; init; }
    public string? Cnpj { get; init; }
    public string? Email { get; init; }
    public string? Endereco { get; init; }
    public string? Telefone { get; init; }
    public string? Ativo { get; init; }
}
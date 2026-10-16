namespace Restaurante.Services.DTOs.Garcom;
public sealed record CriarGarcomDto
{
    public string Nome { get; init; } = default!;
    public string Cpf { get; init; } = default!;
    public string Telefone { get; init; } = default!;
}
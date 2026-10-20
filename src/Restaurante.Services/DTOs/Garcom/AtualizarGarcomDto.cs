namespace Restaurante.Services.DTOs.Garcom;

public sealed record AtualizarGarcomDto
{
    public string Nome { get; init; } = default!;
    public string Cpf { get; init; } = default!;
    public string Telefone { get; init; } = default!;
}
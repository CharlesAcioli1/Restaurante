namespace Restaurante.Services.DTOs.Garcom;

public sealed record AtualizarGarcomDto
{
    public int Id { get; init; }
    public string Nome { get; init; } = default!;
    public string Cpf { get; init; } = default!;
    public string? Telefone { get; init; }
}
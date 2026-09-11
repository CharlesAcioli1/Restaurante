namespace Restaurante.Services.DTOs
{
    public sealed record AtualizarGarcomDto
    {
        public int Id { get; init; }
        public string? Nome { get; init; } = string.Empty;
        public string? Cpf { get; init; } = string.Empty;
        public string? Telefone { get; init; } = string.Empty;
    }
}
namespace Restaurante.Domain;

public sealed class Garcom
{
    public int Id { get; set; }
    public string Nome { get; set; } = default!;
    public string Cpf { get; set; } = default!;
    public string? Telefone { get; set; }
}
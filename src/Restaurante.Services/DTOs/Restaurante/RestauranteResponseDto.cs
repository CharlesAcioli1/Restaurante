namespace Restaurante.Services.DTOs.Restaurante;

public class RestauranteResponseDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cnpj { get; set; }
    public string? Email { get; set; }
    public string? Endereco { get; set; }
    public string? Telefone { get; set; }
    public string? Ativo { get; set; }
}
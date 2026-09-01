namespace Restaurante.Services.DTOs.Restaurante;

public class AtualizarRestauranteDto
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Endereco { get; set; } = string.Empty;
    public string Telefone {get; set; } = string.Empty;
}
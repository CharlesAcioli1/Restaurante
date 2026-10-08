namespace Restaurante.Services.DTOs.Mesa;
public sealed record AtualizarMesaDto
{
    public string? Numero { get; init; }
    public int? StatusId { get; init; }
    public int? RestauranteID {  get; init; }
}
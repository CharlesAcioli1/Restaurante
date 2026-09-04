namespace Restaurante.Services.DTOs.Mesa;
public sealed record AtualizarMesaDto
{
    public int Id { get; init; }
    public int? Numero { get; init; }
    public int? StatusId { get; init; }
}
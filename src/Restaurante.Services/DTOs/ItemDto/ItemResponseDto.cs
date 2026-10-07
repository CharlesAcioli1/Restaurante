using Restaurante.Domain;
namespace Restaurante.Services.DTOs.ItemDto;

public sealed record ItemResponseDto
{
    public int Id { get; init; }
    public string Nome { get; init; } = default!;
    public string Descricao { get; init; } = default!;
    public int CardapioId { get; init; }
public static ItemResponseDto ItemToDto(Item item)
    => new()
    {
        Id = item.Id,
        Nome = item.Nome,
        Descricao = item.Descricao,
        CardapioId = item.CardapioId
    };
}
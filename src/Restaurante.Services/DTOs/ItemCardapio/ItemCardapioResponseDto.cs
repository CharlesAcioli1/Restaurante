using Dom = Restaurante.Domain;
namespace Restaurante.Services.DTOs.ItemCardapio;

public class ItemCardapioResponseDto
{
    public int CardapioId { get; init; }
    public int ItemId { get; init; }
    public decimal Preco { get; init; }

    public static ItemCardapioResponseDto ItemCardapioToDto(Dom.ItemCardapio itemCardapio)
        => new()
        {
            Preco = itemCardapio.Preco,
            ItemId = itemCardapio.ItemId,
            CardapioId = itemCardapio.CardapioId
        };
}

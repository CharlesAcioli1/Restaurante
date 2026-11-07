using Dom = Restaurante.Domain;
namespace Restaurante.Services.DTOs.ItemCardapio;

public sealed record ItemCardapioResponseDto
{
    public int CardapioId { get; init; }
    public int ItemId { get; init; }
    public string? NomeItem { get; init; }
    public string? NomeCardapio { get; init; }
    public string? DescricaoItem { get; init; }
    public decimal Preco { get; init; }

    public static ItemCardapioResponseDto ItemCardapioToDto(Dom.ItemCardapio itemCardapio)
        => new()
        {
            Preco = itemCardapio.Preco,
            ItemId = itemCardapio.ItemId,
            CardapioId = itemCardapio.CardapioId,
            NomeItem = itemCardapio.Item?.Nome,
            NomeCardapio = itemCardapio.Cardapio?.Nome,
            DescricaoItem = itemCardapio.Item?.Descricao
        };
}

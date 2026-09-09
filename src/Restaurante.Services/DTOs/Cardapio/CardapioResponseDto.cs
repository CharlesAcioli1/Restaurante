using Dom = Restaurante.Domain;

namespace Restaurante.Services.DTOs.Cardapio;

public sealed record CardapioResponseDto
{
    public int Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public int RestauranteId { get; init; }

    public static CardapioResponseDto CardapioToDto(Dom.Cardapio cardapio) 
        => new() { Id = cardapio.Id, Nome = cardapio.Nome, RestauranteId = cardapio.RestauranteId };
}
namespace Restaurante.Services.DTOs.ItemCardapio
{
    public sealed record CriarItemCardapioDto
    {
        public int CardapioId { get; init; }
        public int ItemId { get; init; }
        public decimal Preco { get; init; }
    }
}

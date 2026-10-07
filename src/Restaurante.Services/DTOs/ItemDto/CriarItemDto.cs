namespace Restaurante.Services.DTOs.ItemDto
{
    public sealed record CriarItemDto
    {
        public string Nome { get; init; } = default!;
        public string Descricao { get; init; } = default!;
        public int CardapioId { get; init; }
        public int? CozinhaId { get; init; }
    }
}

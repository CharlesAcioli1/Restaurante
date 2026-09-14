namespace Restaurante.Services.DTOs.ItemCardapio
{
    public class AtualizarItemCardapioDto
    {
        public int CardapioId { get; init; }
        public int ItemId { get; init; }
        public decimal Preco { get; init; }
    }
}

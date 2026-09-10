    using Dom = Restaurante.Domain;
    namespace Restaurante.Services.DTOs.Pedido;

    public sealed record PedidoResponseDto
    {
        public int Id { get; init; }
        public int IdMesa { get; init; }
        public int StatusId { get; init; }
        public DateTime DataCriacao { get; init; }

        public static PedidoResponseDto PedidoToDto(Dom.Pedido pedido)
            => new()
            {
                Id = pedido.Id,
                IdMesa = pedido.IdMesa,
                StatusId = pedido.StatusId,
                DataCriacao = pedido.DataCriacao
            };
    }
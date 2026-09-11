using Dom = Restaurante.Domain;
namespace Restaurante.Services.DTOs.Mesa;

public sealed record MesaResponseDto
//  │      │      └ record: Garante imutabilidade por padrão e comparação por valor.
//  │      └ sealed: Evita herança desnecessária e otimiza a execução no Runtime.
//  └ public: Visível para as camadas de Presentation e Services.
{
    public int Id { get; init; }
    public int Numero { get; init; }
    public int StatusId { get; init; }
    public int RestauranteId { get; init; }

    public static MesaResponseDto MesaToDto(Dom.Mesa mesa)
        => new()
        {
            Id = mesa.Id,
            Numero = mesa.Numero,
            StatusId = mesa.StatusId,
            RestauranteId = mesa.RestauranteId
        };
}
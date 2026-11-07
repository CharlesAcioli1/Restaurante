using Restaurante.Domain.Enums;
using Dom = Restaurante.Domain;
namespace Restaurante.Services.DTOs.Mesa;

public sealed record MesaResponseDto

{
    public int Id { get; init; }
    public string StatusMesaId { get; init; } = default!;
    public string Numero { get; init; } = default!;
    public string NomeRestaurante {  get; init; } = default!;
    public int RestauranteId { get; init; }

    public static MesaResponseDto MesaToDto(Dom.Mesa mesa)
    {
        string nomeStatus = mesa.StatusMesa != null
            ? mesa.StatusMesa.StatusId.ToString()
            : nameof(StatusMesaEnum.Desocupada);
        return new()
           {
               Id = mesa.Id,
               Numero = mesa.Numero,
               RestauranteId = mesa.RestauranteId,
               StatusMesaId = nomeStatus,
               NomeRestaurante = mesa.Restaurante?.Nome ?? "Restaurante não encontrado"
           };
    }
}
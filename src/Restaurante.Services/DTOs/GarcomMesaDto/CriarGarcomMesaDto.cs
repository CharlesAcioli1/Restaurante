namespace Restaurante.Services.DTOs.GarcomMesaDto
{
    public sealed record CriarGarcomMesaDto
    {
        public int GarcomId { get; init; }
        public int MesaId { get; init; }
    }
}

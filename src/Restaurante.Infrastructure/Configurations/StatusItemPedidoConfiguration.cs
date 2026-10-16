using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain.Enums;

namespace Restaurante.Infrastructure.Configurations;

public class StatusItemPedidoConfiguration : IEntityTypeConfiguration<Domain.StatusItemPedido>
{
    public void Configure(EntityTypeBuilder<Domain.StatusItemPedido> builder)
    {
        builder.ToTable("StatusItemPedido");

        builder.HasKey(sip => sip.Id);

        builder.Property(sip => sip.Status)
            .IsRequired()
            .HasColumnType("VARCHAR(150)");

        builder.Property(sip => sip.DataHora)
            .IsRequired();

        builder.HasData(
            new Domain.StatusItemPedido { Id = 1, Status = StatusItemPedidoEnum.NaoEntregue},
            new Domain.StatusItemPedido { Id = 2, Status = StatusItemPedidoEnum.Entregue}
            );
    }
}
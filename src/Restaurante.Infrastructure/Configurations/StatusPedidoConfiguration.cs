using Restaurante.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restaurante.Infrastructure.Configurations;

public class StatusPedidoConfiguration : IEntityTypeConfiguration<Domain.StatusPedido>
{
    public void Configure(EntityTypeBuilder<Domain.StatusPedido> builder)
    {
        builder.ToTable("StatusPedido");

        builder.HasKey(sp => sp.Id);

        builder.Property(sp => sp.Status)
            .HasConversion<string>()
            .IsRequired();

        builder.Property(sp => sp.DataHora)
            .IsRequired();

        builder.HasData(
            new Domain.StatusPedido { Id = 1, Status = StatusPedidoEnum.Enviado},
            new Domain.StatusPedido { Id = 2, Status = StatusPedidoEnum.Preparo},
            new Domain.StatusPedido { Id = 3, Status = StatusPedidoEnum.Recebido}
            );
    }
}
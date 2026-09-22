using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restaurante.Infrastructure.Configurations;

public class StatusPedidoConfiguration : IEntityTypeConfiguration<Domain.StatusPedido>
{
    public void Configure(EntityTypeBuilder<Domain.StatusPedido> builder)
    {
        builder.ToTable("StatusPedido");

        builder.HasKey(sp => sp.Id);

        builder.Property(sp => sp.Descricao)
            .IsRequired()
            .HasColumnType("VARCHAR(150)");

        builder.Property(sp => sp.DataHora)
            .IsRequired();
    }
}
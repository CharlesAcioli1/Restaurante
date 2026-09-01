using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class StatusItemPedidoConfiguration : IEntityTypeConfiguration<Domain.StatusItemPedido>
{
    public void Configure(EntityTypeBuilder<Domain.StatusItemPedido> builder)
    {
        builder.ToTable("StatusItemPedido");

        builder.HasKey(sip => sip.Id);

        builder.Property(sip => sip.Descricao)
            .IsRequired()
            .HasColumnType("VARCHAR(150)");

        builder.Property(sip => sip.DataHora)
            .IsRequired()
            .HasColumnType("DATETIME2")
            .HasDefaultValueSql("GETUTCDATE()");
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Domain.Pedido>
{
    public void Configure(EntityTypeBuilder<Domain.Pedido> builder)
    {
        builder.ToTable("Pedido");

        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Mesa)
            .WithMany()
            .HasForeignKey(p => p.IdMesa)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Status)
            .WithMany()
            .HasForeignKey(p => p.StatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.DataCriacao)
            .IsRequired()
            .HasColumnType("DATETIME2")
            .HasDefaultValueSql("GETUTCDATE()");
    }
}
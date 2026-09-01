using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class ItemPedidoConfiguration : IEntityTypeConfiguration<Domain.ItemPedido>
{
    public void Configure(EntityTypeBuilder<Domain.ItemPedido> builder)
    {
        builder.ToTable("ItemPedido");

        builder.HasKey(ip => new {ip.PedidoId, ip.ItemId});

        builder.Property(ip => ip.Quantidade)
            .IsRequired()
            .HasColumnType("INT");

        builder.Property(ip => ip.Descricao)
            .HasColumnType("VARCHAR(250)");

        builder.HasOne(ip => ip.Pedido)
            .WithMany()
            .HasForeignKey(ip => ip.PedidoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ip => ip.Item)
            .WithMany()
            .HasForeignKey(ip => ip.ItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ip => ip.Status)
            .WithMany()
            .HasForeignKey(ip => ip.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
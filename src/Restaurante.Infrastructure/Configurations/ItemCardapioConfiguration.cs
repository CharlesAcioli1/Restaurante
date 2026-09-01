using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class ItemCardapioConfiguration : IEntityTypeConfiguration<Domain.ItemCardapio>
{
    public void Configure(EntityTypeBuilder<Domain.ItemCardapio> builder)
    {
        builder.ToTable("ItemCardapio");

        builder.HasKey(ic => new { ic.CardapioId, ic.ItemId });

        builder.Property(ic => ic.Preco)
            .IsRequired()
            .HasColumnType("DECIMAL(18,2)");

        builder.HasOne(ic => ic.Cardapio)
            .WithMany()
            .HasForeignKey(ic => ic.CardapioId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ic => ic.Item)
            .WithMany()
            .HasForeignKey(ic => ic.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
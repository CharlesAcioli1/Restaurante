using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class CardapioConfiguration : IEntityTypeConfiguration<Domain.Cardapio>
{
    public void Configure(EntityTypeBuilder<Domain.Cardapio> builder)
    {
        builder.ToTable("Cardapio");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder.HasOne(c => c.Restaurante)
            .WithMany()
            .HasForeignKey(c => c.RestauranteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
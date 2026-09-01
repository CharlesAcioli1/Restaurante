using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Domain.Item>
{
    public void Configure(EntityTypeBuilder<Domain.Item> builder)
    {
        builder.ToTable("Item");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Nome)
            .IsRequired()
            .HasColumnType("VARCHAR(150)");

        builder.Property(i => i.Descricao)
            .IsRequired()
            .HasColumnType("VARCHAR(450)");

        builder.HasOne(i => i.Cozinha)
            .WithMany()
            .HasForeignKey(i => i.CozinhaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
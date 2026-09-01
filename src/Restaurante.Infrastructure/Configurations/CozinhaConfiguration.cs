using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class CozinhaConfiguration : IEntityTypeConfiguration<Domain.Cozinha>
{
    public void Configure(EntityTypeBuilder<Domain.Cozinha> builder)
    {
        builder.ToTable("Cozinha");

        builder.HasKey(cz => cz.Id);

        builder.Property(cz => cz.Nome)
            .IsRequired()
            .HasColumnType("VARCHAR(50)");

        builder.HasOne(cz => cz.Restaurante)
            .WithMany()
            .HasForeignKey(cz => cz.RestauranteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(cz => cz.StatusCozinha)
            .WithMany()
            .HasForeignKey(cz => cz.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
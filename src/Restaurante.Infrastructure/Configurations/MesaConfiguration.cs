using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class MesaConfiguration : IEntityTypeConfiguration<Domain.Mesa>
{
    public void Configure(EntityTypeBuilder<Domain.Mesa> builder)
    {
        builder.ToTable("Mesa");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Numero)
            .IsRequired()
            .HasColumnType("INT");

        builder.HasOne(m => m.Restaurante)
            .WithMany()
            .HasForeignKey(m => m.RestauranteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.Status)
            .WithMany()
            .HasForeignKey(m =>m.StatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
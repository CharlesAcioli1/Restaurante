using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restaurante.Infrastructure.Configurations;

public class GarcomRestauranteConfiguration : IEntityTypeConfiguration<Domain.GarcomRestaurante>
{
    public void Configure(EntityTypeBuilder<Domain.GarcomRestaurante> builder)
    {
        builder.ToTable("GarcomRestaurante");

        builder.HasKey(gr => new { gr.GarcomId, gr.RestauranteId });

        builder.Property(gr => gr.DataInicio)
            .IsRequired();

        builder.HasOne(gr => gr.Garcom)
            .WithMany()
            .HasForeignKey(gr => gr.GarcomId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

        builder.HasOne(gr => gr.Restaurante)
            .WithMany()
            .HasForeignKey(gr => gr.RestauranteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
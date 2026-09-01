using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class GarcomMesaConfiguration : IEntityTypeConfiguration<Domain.GarcomMesa>
{
    public void Configure(EntityTypeBuilder<Domain.GarcomMesa> builder)
    {
        builder.ToTable("GarcomMesa");

        builder.HasKey(gm => new { gm.GarcomId, gm.MesaId });

        builder.HasOne(gm => gm.Garcom)
            .WithMany()
            .HasForeignKey(gm => gm.GarcomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(gm => gm.Mesa)
            .WithMany()
            .HasForeignKey(gm => gm.MesaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
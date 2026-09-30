using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restaurante.Infrastructure.Configurations;

public class StatusCozinhaConfiguration : IEntityTypeConfiguration<Domain.StatusCozinha>
{
    public void Configure(EntityTypeBuilder<Domain.StatusCozinha> builder)
    {
        builder.ToTable("StatusCozinha");

        builder.HasKey(sc => sc.Id);

        builder.Property(sc => sc.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(sc => sc.DataHora)
            .IsRequired();
        builder.HasOne(sc => sc.Cozinha)
            .WithMany()
            .HasForeignKey(sc => sc.CozinhaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
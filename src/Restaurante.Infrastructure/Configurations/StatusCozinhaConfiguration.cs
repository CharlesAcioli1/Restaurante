using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restaurante.Infrastructure.Configurations;

public class StatusCozinhaConfiguration : IEntityTypeConfiguration<Domain.StatusCozinha>
{
    public void Configure(EntityTypeBuilder<Domain.StatusCozinha> builder)
    {
        builder.ToTable("StatusCozinha");

        builder.HasKey(sc => sc.Id);

        builder.Property(sc => sc.Descricao)
            .IsRequired()
            .HasColumnType("VARCHAR(250)");

        builder.Property(sc => sc.DataHora)
            .IsRequired();
    }
}
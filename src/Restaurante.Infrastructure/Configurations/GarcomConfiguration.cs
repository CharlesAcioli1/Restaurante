using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class GarcomConfiguration : IEntityTypeConfiguration<Domain.Garcom>
{
    public void Configure(EntityTypeBuilder<Domain.Garcom> builder)
    {
        builder.ToTable("Garcom");

        builder.HasKey(x => x.Id);

        builder.Property(g => g.Nome)
            .IsRequired()
            .HasColumnType("VARCHAR(250)");

        builder.Property(g => g.Cpf)
            .IsRequired()
            .HasColumnType("VARCHAR(11)");

        builder.Property(g => g.Telefone)
            .IsRequired()
            .HasColumnType("VARCHAR(14)");
    }
}
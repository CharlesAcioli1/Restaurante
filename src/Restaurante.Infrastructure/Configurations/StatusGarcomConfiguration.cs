using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class StatusGarcomConfiguration : IEntityTypeConfiguration<Domain.StatusGarcom>
{
    public void Configure(EntityTypeBuilder<Domain.StatusGarcom> builder)
    {
        builder.ToTable("StatusGarcom");

        builder.HasKey(sg => sg.Id);

        builder.Property(sg => sg.Descricao)
            .IsRequired()
            .HasColumnType("VARCHAR(150)");

        builder.Property(sg => sg.DataHora)
            .IsRequired()
            .HasColumnType("DATETIME2")
            .HasDefaultValueSql("GETUTCDATE()");
    }
}
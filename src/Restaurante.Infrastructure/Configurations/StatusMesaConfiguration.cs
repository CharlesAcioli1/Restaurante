using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class StatusMesaConfiguration : IEntityTypeConfiguration<Domain.StatusMesa>
{
    public void Configure(EntityTypeBuilder<Domain.StatusMesa> builder)
    {
        builder.ToTable("StatusMesa");

        builder.HasKey(sm => sm.Id);

        builder.Property(sm => sm.Descricao)
            .IsRequired()
            .HasColumnType("VARCHAR(150)");

        builder.Property(sm => sm.DataHora)
            .IsRequired()
            .HasColumnType("DATETIME2")
            .HasDefaultValueSql("GETUTCDATE()");
    }
}
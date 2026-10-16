using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dom = Restaurante.Domain;
using Restaurante.Domain.Enums;

namespace Restaurante.Infrastructure.Configurations;

public class StatusMesaConfiguration : IEntityTypeConfiguration<Domain.StatusMesa>
{
    public void Configure(EntityTypeBuilder<Domain.StatusMesa> builder)
    {
        builder.ToTable("StatusMesa");

        builder.HasKey(sm => sm.Id);

        builder.Property(sm => sm.StatusId)
            .HasConversion<string>()
            .IsRequired();

        builder.HasData(
            new Dom.StatusMesa { Id = 1, StatusId = StatusMesaEnum.Desocupada},
            new Dom.StatusMesa { Id = 2, StatusId = StatusMesaEnum.Ocupada}
            );
    }
}
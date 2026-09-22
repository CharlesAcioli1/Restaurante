using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Restaurante.Infrastructure.Configurations;

public class FilaPedidoConfiguration : IEntityTypeConfiguration<Domain.FilaPedido>
{
    public void Configure(EntityTypeBuilder<Domain.FilaPedido> builder)
    {
        builder.ToTable("FilaPedido");

        builder.HasKey(fp => fp.Id);

        builder.Property(fp => fp.Prioridade)
            .IsRequired()
            .HasColumnType("VARCHAR(150)");

        builder.HasOne(fp => fp.Pedido)
            .WithMany()
            .HasForeignKey(fp => fp.PedidoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(fp => fp.DataHoraEntrada)
            .IsRequired();
    }
}
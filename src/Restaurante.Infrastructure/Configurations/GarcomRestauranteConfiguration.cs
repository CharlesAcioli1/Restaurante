using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class GarcomRestauranteConfiguration : IEntityTypeConfiguration<Domain.GarcomRestaurante>
{
    public void Configure(EntityTypeBuilder<Domain.GarcomRestaurante> builder)
    {
        builder.ToTable("GarcomRestaurante");
        
        //O uso de new é para criar as chaves compostas.
        builder.HasKey(gr => new {gr.GarcomId, gr.RestauranteId});

        builder.Property(gr => gr.DataInicio)
            .IsRequired();

        builder.HasOne(gr => gr.Status) //<--Garçomrestaurante, tem 1 Status
        .WithMany()//<--Signica que o Status pode estar em vários garçons ao mesmo tempo
        .HasForeignKey(gr => gr.StatusId)//<--Aponta a chave estrangeira a esta classe
        .OnDelete(DeleteBehavior.Restrict);
          // └── Impede a exclusão acidental do Status no banco(RESTRICT).

        builder.HasOne(gr => gr.Garcom)
            .WithMany()
            // └── Avisa que 1 Garçom pode ter várias conexões com restaurantes.
            .HasForeignKey(gr => gr.GarcomId)
            .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

        builder.HasOne(gr => gr.Restaurante)
            .WithMany()
            .HasForeignKey(gr => gr.RestauranteId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
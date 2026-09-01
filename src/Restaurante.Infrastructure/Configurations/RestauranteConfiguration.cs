using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurante.Domain;

namespace Restaurante.Infrastructure.Configurations;

public class RestauranteConfiguration : IEntityTypeConfiguration<Domain.Restaurante>
{
    public void Configure(EntityTypeBuilder<Domain.Restaurante> builder)
    {
        builder.ToTable("Restaurante");
        builder.HasKey(r => r.Id);

        //O nome não pode ser único, devido poder ter franquias
        builder.Property(r => r.Nome)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");

        builder.Property(r => r.Cnpj)
            .IsRequired()
            .HasColumnType("VARCHAR(14)");

        builder.Property(r => r.Email)
            .IsRequired()
            .HasColumnType("VARCHAR(150)");

        builder.Property(r => r.Endereco)
            .IsRequired()
            .HasColumnType("VARCHAR(200)");

        builder.Property(r => r.Telefone)
            .IsRequired()
            .HasColumnType("VARCHAR(20)");

        builder.Property(r => r.Ativo)
            .IsRequired();

        builder.HasIndex(r => r.Cnpj)
            .IsUnique();

        builder.HasIndex(r => r.Email)
            .IsUnique();
    }
}
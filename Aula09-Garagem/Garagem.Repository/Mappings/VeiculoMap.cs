using Garagem.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garagem.Repository.Mappings;

public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("TbVeiculo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.Placa)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(x => x.Cor)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.AnoFabricacao)
            .IsRequired();

        builder.Property(x => x.AnoModelo)
            .IsRequired();

        //Relacionamentos
        builder
            .HasOne(x => x.Modelo)
            .WithMany(x => x.Veiculos)
            .HasConstraintName("FK_Veiculo_Modelo");

    }
}

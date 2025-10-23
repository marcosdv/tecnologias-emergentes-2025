using Garagem.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garagem.Repository.Mappings;

public class ModeloMap : IEntityTypeConfiguration<Modelo>
{
    public void Configure(EntityTypeBuilder<Modelo> builder)
    {
        //Nome da tabela no banco de dados
        builder.ToTable("TbModelo");

        //Chave Primaria
        builder.HasKey(x => x.Id);

        //Configurando campo ID
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        //Configurando o campo Marca
        builder.Property(x => x.Marca)
            .HasColumnName("Marca")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        //Configurando o campo Nome
        builder.Property(x => x.Nome)
            .HasMaxLength(80)
            .IsRequired();
    }
}

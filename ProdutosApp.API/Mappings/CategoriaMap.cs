using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.API.Entities;

namespace ProdutosApp.API.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //nome da tabela
            builder.ToTable("CATEGORIA");

            //chave primária
            builder.HasKey(c => c.Id);

            //mapeamento dos campos da tabela
            builder.Property(c => c.Id).HasColumnName("ID");
            builder.Property(c => c.Nome).HasColumnName("NOME").HasMaxLength(50).IsRequired();

            //mapeamento de campos únicos
            builder.HasIndex(c => c.Nome).IsUnique();
        }
    }
}

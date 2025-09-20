using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.API.Entities;

namespace ProdutosApp.API.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //mapeamento do nome da tabela
            builder.ToTable("PRODUTO");

            //mapeamento do campo chave primária
            builder.HasKey(p => p.Id);

            //mapeamento dos campos da tabela
            builder.Property(p => p.Id).HasColumnName("ID");
            builder.Property(p => p.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Preco).HasColumnName("PRECO").HasColumnType("decimal(10,2)").IsRequired();
            builder.Property(p => p.Quantidade).HasColumnName("QUANTIDADE").IsRequired();
            builder.Property(p => p.DataCriacao).HasColumnName("DATACRIACAO").IsRequired();
            builder.Property(p => p.Ativo).HasColumnName("ATIVO").IsRequired();
            builder.Property(p => p.CategoriaId).HasColumnName("CATEGORIA_ID").IsRequired();

            //mapeamento do relacionamento
            builder.HasOne(p => p.Categoria) //Produto TEM 1 Categoria
                .WithMany(c => c.Produtos) //Categoria TEM Muitos Produtos
                .HasForeignKey(p => p.CategoriaId); //Chave estrangeira
        }
    }
}

using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(m => m.Descricao)
                .HasColumnType("varchar(1000)")
                .IsRequired();

            builder.Property(m => m.Imagem)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(m => m.Valor)
                .HasColumnType("decimal")
                .IsRequired();

            builder.ToTable("Produtos");


        }
    }
}

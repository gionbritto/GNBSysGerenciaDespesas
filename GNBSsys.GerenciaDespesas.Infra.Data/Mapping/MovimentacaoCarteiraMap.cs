using GNBSys.GerenciaDespesas.Domain.Entities.Receita;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Mapping
{
    public class MovimentacaoCarteiraMap : IEntityTypeConfiguration<MovimentacaoCarteira>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoCarteira> builder)
        {
            builder.ToTable("TMovimentacaoCarteira");
            builder.HasKey(m => m.MovimentacaoCarteiraId);
            builder.Property(m => m.Descricao).HasColumnType("varchar(max)").IsRequired();
            builder.Property(m => m.Valor).IsRequired();
            builder.Property(m => m.DataCadastro).IsRequired();
            builder.Property(m => m.DataMovimentacao).IsRequired();

            builder.HasOne(m => m.Mes).WithMany(m => m.MovimentacoesCarteira).HasForeignKey(m => m.MesId);
        }
    }
}

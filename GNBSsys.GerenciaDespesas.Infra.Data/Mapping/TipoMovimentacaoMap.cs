using GNBSys.GerenciaDespesas.Domain.Entities.Receita;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Mapping
{
    public class TipoMovimentacaoCarteiraMap : IEntityTypeConfiguration<TipoMovimentacaoCarteira>
    {
        public void Configure(EntityTypeBuilder<TipoMovimentacaoCarteira> builder)
        {
            builder.ToTable("TTipoMovimentacaoCarteira");
            builder.HasKey(t => t.TipoMovimentacaoCarteiraId);
            builder.Property(t => t.Nome).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();

            builder.HasMany(t => t.MovimentacoesCarteira).WithOne(m => m.TipoMovimentacaoCarteira).HasForeignKey(m => m.TipoMovimentacaoCarteiraId);
        }
    }
}

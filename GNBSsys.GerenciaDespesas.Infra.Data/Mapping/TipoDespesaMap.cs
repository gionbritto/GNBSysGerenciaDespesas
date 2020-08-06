using GNBSys.GerenciaDespesas.Domain.Entities.Despesa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Mapping
{
    public class TipoDespesaMap : IEntityTypeConfiguration<TipoDespesa>
    {
        public void Configure(EntityTypeBuilder<TipoDespesa> builder)
        {
            builder.ToTable("TTipoDespesa");
            builder.HasKey(t => t.TipoDespesaId);
            builder.Property(t => t.Nome).HasColumnType("varchar(50)").HasMaxLength(50).IsRequired();

            builder.HasMany(t => t.Despesas).WithOne(d => d.TipoDespesa).HasForeignKey(d => d.TipoDespesaId);
        }
    }
}

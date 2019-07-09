using GNBSys.GerenciaDespesas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Mapping
{
    public class DespesaMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.ToTable("TDespesa");
            builder.HasKey(d => d.DespesaId);
            builder.Property(d => d.Valor).IsRequired();

            builder.HasOne(d => d.Mes).WithMany(m => m.Despesas).HasForeignKey(d => d.MesId);
            builder.HasOne(d => d.TipoDepesa).WithMany(t => t.Despesas).HasForeignKey(d => d.TipoDespesaId);
        }
    }
}

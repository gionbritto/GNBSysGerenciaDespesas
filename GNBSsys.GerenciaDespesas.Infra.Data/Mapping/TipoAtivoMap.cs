using GNBSys.GerenciaDespesas.Domain.Entities.Receita;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Mapping
{
    public class TipoAtivoMap : IEntityTypeConfiguration<TipoAtivo>
    {
        public void Configure(EntityTypeBuilder<TipoAtivo> builder)
        {
            builder.ToTable("TTipoAtivo");
            builder.HasKey(t => t.TipoAtivoId);
            builder.Property(t => t.Nome).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();

            builder.HasMany(t => t.Ativos).WithOne(a => a.TipoAtivo).HasForeignKey(a => a.TipoAtivoId);
        }
    }
}

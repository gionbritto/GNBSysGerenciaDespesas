using GNBSys.GerenciaDespesas.Domain.Entities.Receita;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Mapping
{
    public class AtivoMap : IEntityTypeConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.ToTable("TAtivo");
            builder.HasKey(a => a.AtivoId);
            builder.Property(a => a.Nome).HasColumnType("varchar(100)").HasMaxLength(100).IsRequired();

            builder.HasOne(a => a.TipoAtivo).WithMany(t => t.Ativos).HasForeignKey(a => a.TipoAtivoId);
            builder.HasMany((System.Linq.Expressions.Expression<Func<Ativo, IEnumerable<MovimentacaoCarteira>>>)(a => (IEnumerable<MovimentacaoCarteira>)a.MovimentacoesCarteira)).WithOne(m => m.Ativo).HasForeignKey(m => m.AtivoId);
            builder.HasMany(a => a.AtivosCarteira).WithOne(a => a.Ativo).HasForeignKey(a => a.AtivoId);
        }
    }
}

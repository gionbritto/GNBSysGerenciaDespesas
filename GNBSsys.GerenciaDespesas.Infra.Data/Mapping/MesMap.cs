using GNBSys.GerenciaDespesas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Mapping
{
    public class MesMap : IEntityTypeConfiguration<Mes>
    {
        public void Configure(EntityTypeBuilder<Mes> builder)
        {
            builder.ToTable("TMes");
            builder.HasKey(m => m.MesId);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();

            builder.HasOne(m => m.Salario).WithOne(s => s.Mes).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m => m.Despesas).WithOne(d => d.Mes).HasForeignKey(d => d.MesId).OnDelete(DeleteBehavior.Cascade);

        }
        
    }
}

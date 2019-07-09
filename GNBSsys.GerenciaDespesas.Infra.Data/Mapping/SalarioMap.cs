using GNBSys.GerenciaDespesas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Mapping
{
    public class SalarioMap : IEntityTypeConfiguration<Salario>
    {
        public void Configure(EntityTypeBuilder<Salario> builder)
        {
            builder.ToTable("TSalario");
            builder.HasKey(s => s.SalarioId);
            builder.Property(s => s.Valor).IsRequired();

            builder.HasOne(s => s.Mes).WithOne(m => m.Salario).HasForeignKey<Salario>(s => s.MesId);
        }
    }
}

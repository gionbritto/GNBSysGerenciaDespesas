using GNBSys.GerenciaDespesas.Domain.Entities.Receita;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Mapping
{
    public class CarteiraMap : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> builder)
        {
            builder.ToTable("TCarteira");
            builder.HasKey(c => c.CarteiraId);
            builder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.Valor).IsRequired();
            builder.HasMany(c => c.AtivosCarteira).WithOne(a => a.Carteira).HasForeignKey(a => a.CarteiraId);
            builder.HasMany(c => c.MovimentacoesCarteira).WithOne(m => m.Carteira).HasForeignKey(m => m.CarteiraId);
        }
    }
}

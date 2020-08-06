using GNBSys.GerenciaDespesas.Domain.Entities.Receita;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Mapping
{
    class AtivoCarteiraMap : IEntityTypeConfiguration<AtivoCarteira>
    {
        public void Configure(EntityTypeBuilder<AtivoCarteira> builder)
        {
            builder.ToTable("TAtivoCarteira");
            builder.HasKey(ac => new { ac.AtivoId, ac.CarteiraId });
        }
    }
}

using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GNBSsys.GerenciaDespesas.Infra.Data.Context
{
    public class GerenciaDespesaContext : DbContext
    {
        public GerenciaDespesaContext(DbContextOptions<GerenciaDespesaContext> op) : base(op)
        {                
        }

        public DbSet<Mes> TMes { get; set; }
        public DbSet<TipoDespesa> TTipoDespesas { get; set; }
        public DbSet<Salario> TSalario { get; set; }
        public DbSet<Despesa> TDespesa { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new TipoDespesaMap());
            mb.ApplyConfiguration(new DespesaMap());
            mb.ApplyConfiguration(new MesMap());
            mb.ApplyConfiguration(new SalarioMap());
        }
    }
}

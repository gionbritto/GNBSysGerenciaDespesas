using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Domain.Entities.Despesa;
using GNBSys.GerenciaDespesas.Domain.Entities.Receita;
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
        public DbSet<TipoMovimentacaoCarteira> TTipoMovimentacaoCarteira { get; set; }
        public DbSet<TipoAtivo> TTipoAtivo { get; set; }
        public DbSet<Ativo> TAtivo { get; set; }
        public DbSet<Carteira> TCarteira { get; set; }
        public DbSet<AtivoCarteira> TAtivoCarteira { get; set; }
        public DbSet<MovimentacaoCarteira> TMovimentacaoCarteira { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new TipoDespesaMap());
            mb.ApplyConfiguration(new DespesaMap());
            mb.ApplyConfiguration(new MesMap());
            mb.ApplyConfiguration(new TipoMovimentacaoCarteiraMap());
            mb.ApplyConfiguration(new TipoAtivoMap());
            mb.ApplyConfiguration(new AtivoMap());
            mb.ApplyConfiguration(new CarteiraMap());
            mb.ApplyConfiguration(new AtivoCarteiraMap());
            mb.ApplyConfiguration(new MovimentacaoCarteiraMap());
        }
    }
}

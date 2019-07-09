using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Domain.Interfaces;

namespace GNBSys.GerenciaDespesas.Infra.Data.Repository
{
    public class TipoDespesaRepository : Repository<TipoDespesa>, ITipoDespesaRepository
    {
        public TipoDespesaRepository(GerenciaDespesaContext ctx) : base (ctx)
        {
        }
    }
}

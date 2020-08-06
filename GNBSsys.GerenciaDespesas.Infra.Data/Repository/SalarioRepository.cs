using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Infra.Data.Repository
{
    public class SalarioRepository : Repository<Salario>, ISalarioRepository
    {
        private readonly GerenciaDespesaContext _ctx;

        public SalarioRepository(GerenciaDespesaContext ctx) : base(ctx)
        {
            _ctx = ctx;            
        }

        public async Task<IEnumerable<Mes>> ObterMeses()
        {
            var meses = await _ctx.Set<Mes>().ToArrayAsync();
            return meses;
        }

        public async Task<IEnumerable<Mes>> ObterMesesSync()
        {
            var meses = await _ctx.Set<Mes>().ToArrayAsync();
            return meses;
        }
        
        public async Task<Mes> ObterMesesPorId(int id)
        {
            var mes = await _ctx.Set<Mes>().FindAsync(id);
            return mes;
        }
    }
}

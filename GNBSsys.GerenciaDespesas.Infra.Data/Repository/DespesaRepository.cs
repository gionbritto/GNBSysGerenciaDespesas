using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Domain.Entities.Despesa;
using GNBSys.GerenciaDespesas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Infra.Data.Repository
{
    public class DespesaRepository : Repository<Despesa>, IDespesaRepository
    {
        private readonly GerenciaDespesaContext _ctx;

        public DespesaRepository(GerenciaDespesaContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Mes>> ObterMeses()
        {
            var meses = await _ctx.Set<Mes>().ToArrayAsync();
            return meses;
        }

        public async Task<Mes> ObterMesesPorId(int id)
        {
            var mes = await _ctx.Set<Mes>().FindAsync(id);
            return mes;
        }

        public async Task<TipoDespesa> ObterTipoDespesaPorId(Guid id)
        {
            var tipoDespesa = await _ctx.Set<TipoDespesa>().FindAsync(id);
            return tipoDespesa;

        }

        public async Task<IEnumerable<TipoDespesa>> ObterTipoDespesas()
        {
            var tipoDepesa = await _ctx.Set<TipoDespesa>().ToArrayAsync();
            return tipoDepesa;
        }

        public GastosTotaisMes RetornarDadosGastosTotaisMes(int mesId)
        {
            GastosTotaisMes gastos = new GastosTotaisMes();
            gastos.ValorTotalGasto = _ctx.TDespesa.Where(x => x.Mes.MesId == mesId).Sum(x => x.Valor);
            gastos.Salario = _ctx.TSalario.Where(x => x.Mes.MesId == mesId).Select(x => x.Valor).FirstOrDefault();
            return gastos;
        }

        public EstatisticasDespesas RetornarDadosEstatisticasDespesas()
        {
            EstatisticasDespesas estatisticasDespesas = new EstatisticasDespesas();
            if (_ctx.TDespesa.Any())
            {
                estatisticasDespesas.MenorDespesa = _ctx.TDespesa.Min(x => x.Valor);
                estatisticasDespesas.MaiorDespesa = _ctx.TDespesa.Max(x => x.Valor);
                estatisticasDespesas.QuantidadeDespesas = _ctx.TDespesa.Count();
                return estatisticasDespesas;
            }
            return null;
        }
            

    }
}

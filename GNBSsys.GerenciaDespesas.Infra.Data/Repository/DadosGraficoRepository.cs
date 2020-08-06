using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Infra.Data.Repository
{
    public class DadosGraficoRepository : IDadosGraficosRepository
    {
        private readonly GerenciaDespesaContext _ctx;

        public DadosGraficoRepository(GerenciaDespesaContext ctx)
        {
            _ctx = ctx;
        }

        public List<DadosGraficos> RetornarDadosGastosMes(int mesId)
        {
            try
            {
                var dados = (from d in _ctx.TDespesa
                             where d.Mes.MesId == mesId
                             group d by d.TipoDespesa.Nome into g
                             select new DadosGraficos
                             {
                                 TiposDespesas = g.Key,
                                 Valores = g.Sum(d => d.Valor)
                             }).ToList();

                return dados;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<DadosGraficos> RetornarDadosGraficoGastosTotais()
        {
            try
            {
                var dados = _ctx.TDespesa
                            .OrderBy(x => x.MesId)
                            .GroupBy(x => x.MesId)
                            .Select(x => new DadosGraficos
                            {
                                NomeMeses = x.Select(m => m.Mes.Nome).Distinct().First(),
                                Valores = x.Sum(d => d.Valor)
                            }).ToList();
                return dados;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Application.Interfaces;
using GNBSys.GerenciaDespesas.Application.ViewModels;
using GNBSys.GerenciaDespesas.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNBSys.GerenciaDespesas.Application
{
    public class DadosGraficosAppService : IDadosGraficosAppService
    {
        private readonly DadosGraficoRepository _dadosGraficoRepository;

        public DadosGraficosAppService(GerenciaDespesaContext ctx)
        {
            _dadosGraficoRepository = new DadosGraficoRepository(ctx);
        }

        public List<DadosGraficosViewModel> RetornarDadosGastosMes(int mesId)
        {
            var dadosEntidade = _dadosGraficoRepository.RetornarDadosGastosMes(mesId);
            List<DadosGraficosViewModel> dadosGraficosViewModel = new List<DadosGraficosViewModel>();

            dadosEntidade.ForEach(x => dadosGraficosViewModel.Add(new DadosGraficosViewModel
            {
                TiposDespesas = x.TiposDespesas,
                Valores = x.Valores
            }));

            return dadosGraficosViewModel;
        }

        public List<DadosGraficosViewModel> RetornarDadosGraficoGastosTotais()
        {
            var dadosEntidade = _dadosGraficoRepository.RetornarDadosGraficoGastosTotais();
            List<DadosGraficosViewModel> dadosGraficosViewModel =  new List<DadosGraficosViewModel>();

            dadosEntidade.ForEach(x => dadosGraficosViewModel.Add(new DadosGraficosViewModel
            {
                NomeMeses = x.NomeMeses,
                Valores = x.Valores
            }));

            return dadosGraficosViewModel;
        }
    }
}

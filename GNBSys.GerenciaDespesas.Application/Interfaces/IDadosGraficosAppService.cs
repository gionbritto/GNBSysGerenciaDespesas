using GNBSys.GerenciaDespesas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNBSys.GerenciaDespesas.Application.Interfaces
{
    public interface IDadosGraficosAppService
    {
        List<DadosGraficosViewModel> RetornarDadosGraficoGastosTotais();
        List<DadosGraficosViewModel> RetornarDadosGastosMes(int mesId);
    }
}

using GNBSys.GerenciaDespesas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Domain.Interfaces
{
    public interface IDadosGraficosRepository
    {
        List<DadosGraficos> RetornarDadosGraficoGastosTotais();
        List<DadosGraficos> RetornarDadosGastosMes(int mesId);
    }
}

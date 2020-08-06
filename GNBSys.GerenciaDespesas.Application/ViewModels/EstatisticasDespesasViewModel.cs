using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Application.ViewModels
{
    public class EstatisticasDespesasViewModel
    {
        public int QuantidadeDespesas { get; set; }
        public double MenorDespesa { get; set; }
        public double MaiorDespesa { get; set; }
    }
}

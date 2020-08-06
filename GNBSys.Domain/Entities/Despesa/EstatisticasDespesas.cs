using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Domain.Entities.Despesa
{
    public class EstatisticasDespesas
    {
        public int QuantidadeDespesas { get; set; }
        public double MenorDespesa { get; set; }
        public double MaiorDespesa { get; set; }
    }
}

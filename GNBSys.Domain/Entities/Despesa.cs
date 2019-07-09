using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Domain.Entities
{
    public class Despesa
    {
        public Guid DespesaId { get; set; }
        public Guid TipoDespesaId { get; set; }
        public int MesId { get; set; }
        public double Valor { get; set; }

        public TipoDespesa TipoDepesa { get; set; }
        public Mes Mes { get; set; }
    }
}

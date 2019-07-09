using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Domain.Entities
{
    public class TipoDespesa
    {
        public Guid TipoDespesaId { get; set; }
        public string Nome { get; set; }

        public ICollection<Despesa> Despesas { get; set; }
    }
}

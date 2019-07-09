using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Domain.Entities
{
    public class Mes
    {
        public int MesId { get; set; }
        public string Nome { get; set; }

        public Salario Salario { get; set; }
        public ICollection<Despesa> Despesas { get; set; }
    }
}

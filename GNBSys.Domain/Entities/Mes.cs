using GNBSys.GerenciaDespesas.Domain.Entities.Receita;
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
        public ICollection<Despesa.Despesa> Despesas { get; set; }
        public ICollection<MovimentacaoCarteira> MovimentacoesCarteira { get; set; }
    }
}

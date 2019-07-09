using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Domain.Entities
{
    public class Salario
    {
        public Guid SalarioId { get; set; }
        public double Valor { get; set; }
        public int MesId { get; set; }

        public Mes Mes { get; set; }
    }
}

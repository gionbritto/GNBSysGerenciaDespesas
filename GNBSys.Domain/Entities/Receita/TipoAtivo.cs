using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Domain.Entities.Receita
{
    public class TipoAtivo
    {
        public Guid TipoAtivoId { get; set; }
        public string Nome { get; set; }

        public ICollection<Ativo> Ativos { get; set; }
    }
}

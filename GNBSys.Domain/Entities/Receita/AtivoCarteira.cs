using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Domain.Entities.Receita
{
    public class AtivoCarteira
    {
        public Guid AtivoId { get; set; }
        public Guid CarteiraId { get; set; }
        public Ativo Ativo { get; set; }
        public Carteira Carteira { get; set; }
    }
}

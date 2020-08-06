using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Domain.Entities.Receita
{
    public class TipoMovimentacaoCarteira
    {
        public int TipoMovimentacaoCarteiraId { get; set; }
        public string Nome { get; set; }

        public ICollection<MovimentacaoCarteira> MovimentacoesCarteira { get; set; }
    }
}

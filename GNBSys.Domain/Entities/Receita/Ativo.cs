using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Domain.Entities.Receita
{
    public class Ativo
    {
        public Guid AtivoId { get; set; }
        public Guid TipoAtivoId { get; set; }
        public string Nome { get; set; }

        public TipoAtivo TipoAtivo { get; set; }

        //o mesmo ativo pode estar em varias movimentacoes
        public ICollection<MovimentacaoCarteira> MovimentacoesCarteira { get; set; }
        public ICollection<AtivoCarteira> AtivosCarteira { get; set; }
    }
}

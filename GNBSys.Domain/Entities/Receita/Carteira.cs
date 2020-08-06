using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Domain.Entities.Receita
{
    public class Carteira
    {
        public Guid CarteiraId { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public ICollection<MovimentacaoCarteira> MovimentacoesCarteira { get; set; }
        public ICollection<AtivoCarteira> AtivosCarteira { get; set; }
    }
}

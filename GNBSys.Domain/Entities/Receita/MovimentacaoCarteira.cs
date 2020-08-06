using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Domain.Entities.Receita
{
    public class MovimentacaoCarteira
    {
        public Guid MovimentacaoCarteiraId { get; set; }
        public int TipoMovimentacaoCarteiraId { get; set; }
        public Guid CarteiraId { get; set; }
        public Guid AtivoId { get; set; }
        public int MesId { get; set; }
        public double Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string Descricao { get; set; }

        public TipoMovimentacaoCarteira TipoMovimentacaoCarteira { get; set; }
        public Carteira Carteira { get; set; }
        public Mes Mes { get; set; }
        public Ativo Ativo { get; set; }
    }
}

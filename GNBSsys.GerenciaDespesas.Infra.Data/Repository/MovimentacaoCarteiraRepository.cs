using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Domain.Entities.Receita;
using GNBSys.GerenciaDespesas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Repository
{
    public class MovimentacaoCarteiraRepository : Repository<MovimentacaoCarteira>, IMovimentacaoCarteiraRepository
    {
        public MovimentacaoCarteiraRepository(GerenciaDespesaContext ctx) : base(ctx)
        {
        }
    }
}

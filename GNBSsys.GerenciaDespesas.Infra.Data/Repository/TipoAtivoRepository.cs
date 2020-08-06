using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Domain.Entities.Receita;
using GNBSys.GerenciaDespesas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Repository
{
    public class TipoAtivoRepository : Repository<TipoAtivo>, ITipoAtivoRepository
    {
        public TipoAtivoRepository(GerenciaDespesaContext ctx) : base(ctx)
        {
        }
    }
}

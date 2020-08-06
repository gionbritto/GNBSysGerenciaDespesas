using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Repository
{
    public class MesRepository : Repository<Mes>, IMesRepository
    {
        public MesRepository(GerenciaDespesaContext ctx) : base(ctx)
        {
        }
    }
}

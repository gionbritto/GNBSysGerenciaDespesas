using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Domain.Entities.Receita;
using GNBSys.GerenciaDespesas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GNBSys.GerenciaDespesas.Infra.Data.Repository
{
    public class CarteiraRepository : Repository<Carteira>, ICarteiraRepository
    {
        public CarteiraRepository(GerenciaDespesaContext ctx) : base(ctx)
        {
        }
    }
}

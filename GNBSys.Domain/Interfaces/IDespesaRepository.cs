using GNBSys.GerenciaDespesas.Domain.Entities.Despesa;
using GNBSys.GerenciaDespesas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Domain.Interfaces
{
    public interface IDespesaRepository : IRepository<Despesa>
    {
        Task<IEnumerable<Mes>> ObterMeses();
        Task<Mes> ObterMesesPorId(int id);
        Task<IEnumerable<TipoDespesa>> ObterTipoDespesas();
        Task<TipoDespesa> ObterTipoDespesaPorId(Guid id);
        GastosTotaisMes RetornarDadosGastosTotaisMes(int mesId);
    }
}

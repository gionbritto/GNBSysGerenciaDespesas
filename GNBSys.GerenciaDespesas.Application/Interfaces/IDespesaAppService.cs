using GNBSys.GerenciaDespesas.Application.ViewModels;
using GNBSys.GerenciaDespesas.Domain.Entities.Despesa;
using GNBSys.GerenciaDespesas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Application.Interfaces
{
    interface IDespesaAppService
    {
        Task<DespesaViewModel> Adicionar(DespesaViewModel despesaViewModel);
        Task<DespesaViewModel> Atualizar(DespesaViewModel despesaViewModel);
        List<DespesaViewModel> Buscar(Expression<Func<DespesaViewModel, bool>> predicate);
        Task<DespesaViewModel> ObterPorId(Guid? id);
        Task RemoverAsync(Guid id);
        Task<List<DespesaViewModel>> ObterTodos();
        Task<IEnumerable<Mes>> ObterMeses();
        Task<IEnumerable<TipoDespesa>> ObterTipoDepesas();
        GastosTotaisMesViewModel RetornarDadosGastosTotaisMes(int mesId);
        EstatisticasDespesasViewModel RetornarDadosEstatisticasDespesas();
    }
}

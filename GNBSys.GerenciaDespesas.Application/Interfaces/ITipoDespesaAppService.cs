using GNBSys.GerenciaDespesas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Application.Interfaces
{
    public interface ITipoDespesaAppService : IDisposable
    {
        Task<TipoDespesaViewModel> Adicionar(TipoDespesaViewModel tipoDespesaViewModel);
        Task<TipoDespesaViewModel> Atualizar(TipoDespesaViewModel tipoDespesaViewModel);
        List<TipoDespesaViewModel> Buscar(Expression<Func<TipoDespesaViewModel, bool>> predicate);
        Task<TipoDespesaViewModel> ObterPorId(Guid? id);
        Task RemoverAsync(Guid id);
        Task<List<TipoDespesaViewModel>> ObterTodos();
    }
}

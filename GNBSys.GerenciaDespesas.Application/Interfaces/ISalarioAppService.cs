using GNBSys.GerenciaDespesas.Application.ViewModels;
using GNBSys.GerenciaDespesas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Application.Interfaces
{
    interface ISalarioAppService
    {
        Task<SalarioViewModel> Adicionar(SalarioViewModel salarioViewModel);
        Task<SalarioViewModel> Atualizar(SalarioViewModel salarioViewModel);
        List<SalarioViewModel> Buscar(Expression<Func<SalarioViewModel, bool>> predicate);
        Task<SalarioViewModel> ObterPorId(Guid? id);
        Task RemoverAsync(Guid id);
        Task<List<SalarioViewModel>> ObterTodos();
        Task<IEnumerable<Mes>> ObterMeses();
    }
}

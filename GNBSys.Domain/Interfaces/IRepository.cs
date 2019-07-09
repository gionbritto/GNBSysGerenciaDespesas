using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<int> Adicionar(TEntity obj);
        Task<TEntity> ObterPorId(Guid? id);
        Task<List<TEntity>> ObterTodos();
        Task<TEntity> Atualizar(TEntity obj);
        Task RemoverAsync(Guid id);
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}

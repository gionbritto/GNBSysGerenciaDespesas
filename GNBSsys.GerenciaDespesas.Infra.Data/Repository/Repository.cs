using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GNBSys.GerenciaDespesas.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly GerenciaDespesaContext _ctx;
        protected DbSet<TEntity> dbSet;

        public Repository(GerenciaDespesaContext ctx)
        {
            _ctx = ctx;
            dbSet = _ctx.Set<TEntity>();
        }

        public async Task<int> Adicionar(TEntity obj)
        {
            var objreturn = dbSet.AddAsync(obj);
            return await SaveChanges();            
        }

        public async Task<TEntity> Atualizar(TEntity obj)
        {
            var entry = _ctx.Entry(obj);
            dbSet.Attach(obj);
            entry.State = EntityState.Modified;
            await SaveChanges();

            return obj;
        }

        public List<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public void Dispose()
        {
            _ctx.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<TEntity> ObterPorId(Guid? id) //TODO Giovanne - Testar entrada nula
        {
            return await dbSet.FindAsync(id);
        }

        public Task<List<TEntity>> ObterTodos()
        {
            return dbSet.ToListAsync();
        }

        public async Task RemoverAsync(Guid id)
        {
            var x = await ObterPorId(id);
            dbSet.Remove(x);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _ctx.SaveChangesAsync();
        }
    }
}

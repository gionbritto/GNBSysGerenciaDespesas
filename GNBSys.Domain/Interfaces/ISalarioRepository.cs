using GNBSys.GerenciaDespesas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Domain.Interfaces
{
    public interface ISalarioRepository : IRepository<Salario>
    {
        Task<IEnumerable<Mes>> ObterMeses();
        Task<Mes> ObterMesesPorId(int id);
    }
}

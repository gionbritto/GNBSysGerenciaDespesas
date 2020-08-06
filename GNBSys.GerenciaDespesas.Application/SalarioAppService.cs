using AutoMapper;
using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Application.Interfaces;
using GNBSys.GerenciaDespesas.Application.ViewModels;
using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Application
{
    public class SalarioAppService : ISalarioAppService
    {
        private readonly SalarioRepository _salarioRepository;
        private readonly IMapper _mapper;
            //1° - Recebe da interface e transforma no tipo entity
            //2° - Apos ter o tipo chama o metodo responsavel na camada de infra (Repositorio)
        public SalarioAppService(GerenciaDespesaContext ctx, IMapper mapper)
        {
            _salarioRepository = new SalarioRepository(ctx);
            _mapper = mapper;
        }

        public async Task<SalarioViewModel> Adicionar(SalarioViewModel salarioViewModel)
        {
            var salario = _mapper.Map<SalarioViewModel, Salario>(salarioViewModel);
            await _salarioRepository.Adicionar(salario);

            return salarioViewModel;
        }

        public async Task<SalarioViewModel> Atualizar(SalarioViewModel salarioViewModel)
        {
            var salario = _mapper.Map<SalarioViewModel, Salario>(salarioViewModel);
            await _salarioRepository.Atualizar(salario);

            return salarioViewModel;
        }

        public List<SalarioViewModel> Buscar(Expression<Func<SalarioViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Mes>> ObterMeses()
        {
            var meses = await _salarioRepository.ObterMeses();
            return meses;
        }

        //public IEnumerable<Mes> ObterMesesSync()
        //{
        //    var meses =  _salarioRepository.ObterMesesSync();
        //    return meses;
        //}

        public async Task<SalarioViewModel> ObterPorId(Guid? id)
        {
            var salario = await _salarioRepository.ObterPorId(id);

            return _mapper.Map<Salario, SalarioViewModel>(salario);
        }

        public async Task<List<SalarioViewModel>> ObterTodos()
        {
            var salarios = await _salarioRepository.ObterTodos();
            IEnumerable<Mes> meses = await _salarioRepository.ObterMeses();
            salarios.ForEach(x => x.Mes = meses.Where(m => m.MesId == x.MesId).First());
            return _mapper.Map<List<Salario>, List<SalarioViewModel>>(salarios);
        }

        public async Task RemoverAsync(Guid id)
        {
            await _salarioRepository.RemoverAsync(id);
        }
    }
}

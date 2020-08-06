using AutoMapper;
using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Application.Interfaces;
using GNBSys.GerenciaDespesas.Application.ViewModels;
using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Domain.Entities.Despesa;
using GNBSys.GerenciaDespesas.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Application
{
    public class DespesaAppService : IDespesaAppService
    {
        private readonly DespesaRepository _despesaRepository;
        private readonly IMapper _mapper;
        //1° - Recebe da interface e transforma no tipo entity
        //2° - Apos ter o tipo chama o metodo responsavel na camada de infra (Repositorio)
        public DespesaAppService(GerenciaDespesaContext ctx, IMapper mapper)
        {
            _despesaRepository = new DespesaRepository(ctx);
            _mapper = mapper;
        }
        //usa o Map<Fonte, Destino>
        public async Task<DespesaViewModel> Adicionar(DespesaViewModel despesaViewModel)
        {
            var _despesa = new Despesa
            {
                DespesaId = despesaViewModel.DespesaId,
                MesId = despesaViewModel.MesId,
                TipoDespesaId = despesaViewModel.TipoDespesaId,
                Valor = despesaViewModel.Valor
            };

            await _despesaRepository.Adicionar(_despesa);

            return despesaViewModel;
        }

        public async Task<DespesaViewModel> Atualizar(DespesaViewModel despesaViewModel)
        {
            var _despesa = new Despesa
            {
                DespesaId = despesaViewModel.DespesaId,
                MesId = despesaViewModel.MesId,
                TipoDespesaId = despesaViewModel.TipoDespesaId,
                Valor = despesaViewModel.Valor
            };
            await _despesaRepository.Atualizar(_despesa);

            return despesaViewModel;
        }

        public List<DespesaViewModel> Buscar(Expression<Func<DespesaViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<DespesaViewModel> ObterPorId(Guid? id)
        {
            var _despesa = await _despesaRepository.ObterPorId(id);

            var _despesaViewModel = new DespesaViewModel
            {
                DespesaId = _despesa.DespesaId,
                MesId = _despesa.MesId,
                TipoDespesaId = _despesa.TipoDespesaId,
                Valor = _despesa.Valor
            };
            return _despesaViewModel;
        }

        public async Task<List<DespesaViewModel>> ObterTodos()
        {
            var despesas = await _despesaRepository.ObterTodos();
            List<DespesaViewModel> despesaViewModels = new List<DespesaViewModel>();
            IEnumerable<Mes> meses = await _despesaRepository.ObterMeses();
            IEnumerable<TipoDespesa> tipoDespesas = await _despesaRepository.ObterTipoDespesas();
            despesas.ForEach(x => despesaViewModels.Add(new DespesaViewModel
            {
                DespesaId = x.DespesaId,                
                Mes = meses.Where(m => m.MesId == x.MesId).First(),
                TipoDespesa = tipoDespesas.Where(d => d.TipoDespesaId == x.TipoDespesaId).First(),
                Valor = x.Valor
            }));
            return despesaViewModels;
        }

        public async Task RemoverAsync(Guid id)
        {
            await _despesaRepository.RemoverAsync(id);
        }

        public async Task<IEnumerable<Mes>> ObterMeses()
        {
            var meses = await _despesaRepository.ObterMeses();
            return meses;
        }

        public async Task<IEnumerable<TipoDespesa>> ObterTipoDepesas()
        {
            var tipoDespesas = await _despesaRepository.ObterTipoDespesas();
            return tipoDespesas;
        }

        public GastosTotaisMesViewModel RetornarDadosGastosTotaisMes(int mesId)
        {
            var dadosGastosEntidade = _despesaRepository.RetornarDadosGastosTotaisMes(mesId);
            var dadosGastosViewModel = new GastosTotaisMesViewModel
            {
                ValorTotalGasto = dadosGastosEntidade.ValorTotalGasto,
                Salario = dadosGastosEntidade.Salario
            };
            return dadosGastosViewModel;
        }

        public EstatisticasDespesasViewModel RetornarDadosEstatisticasDespesas()
        {
            var estatisticasDespesasEntidade = _despesaRepository.RetornarDadosEstatisticasDespesas();
            if(estatisticasDespesasEntidade != null)
            {
                var estatisticasDespesasViewModel = new EstatisticasDespesasViewModel
                {
                    MenorDespesa = estatisticasDespesasEntidade.MenorDespesa,
                    MaiorDespesa = estatisticasDespesasEntidade.MaiorDespesa,
                    QuantidadeDespesas = estatisticasDespesasEntidade.QuantidadeDespesas
                };
                return estatisticasDespesasViewModel;
            }
            return null;

        }
    }
}

using AutoMapper;
using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Application.Interfaces;
using GNBSys.GerenciaDespesas.Application.ViewModels;
using GNBSys.GerenciaDespesas.Domain.Entities.Despesa;
using GNBSys.GerenciaDespesas.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GNBSys.GerenciaDespesas.Application
{
    public class TipoDespesaAppService : ITipoDespesaAppService
    {
        private readonly TipoDespesaRepository _tipoDespesaRepository;
        private readonly IMapper _mapper;

        public TipoDespesaAppService(GerenciaDespesaContext ctx, IMapper mapper)
        {
            _tipoDespesaRepository = new TipoDespesaRepository(ctx);
            _mapper = mapper;

        }

        public async Task<TipoDespesaViewModel> Adicionar(TipoDespesaViewModel tipoDespesaViewModel)
        {
            var tipoDespesa = _mapper.Map<TipoDespesaViewModel, TipoDespesa>(tipoDespesaViewModel);

            await _tipoDespesaRepository.Adicionar(tipoDespesa);

            return tipoDespesaViewModel;
        }

        public async Task<TipoDespesaViewModel> Atualizar(TipoDespesaViewModel tipoDespesaViewModel)
        {
            await _tipoDespesaRepository.Atualizar(_mapper.Map<TipoDespesaViewModel, TipoDespesa>(tipoDespesaViewModel));
            return tipoDespesaViewModel;
        }


        public List<TipoDespesaViewModel> Buscar(Expression<Func<TipoDespesaViewModel, bool>> predicate)
        {
            var _predicate = _mapper.Map<Expression<Func<TipoDespesaViewModel, bool>>, Expression<Func<TipoDespesa, bool>>>(predicate);
            var result = _tipoDespesaRepository.Buscar(_predicate);

            return _mapper.Map<List<TipoDespesa>, List<TipoDespesaViewModel>>(result);
        }

        public void Dispose()
        {
            _tipoDespesaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<TipoDespesaViewModel> ObterPorId(Guid? id)
        {
            return _mapper.Map<TipoDespesa,  TipoDespesaViewModel> (await _tipoDespesaRepository.ObterPorId(id));
        }

        public async Task<List<TipoDespesaViewModel>> ObterTodos()
        {
            return _mapper.Map<List<TipoDespesa>, List<TipoDespesaViewModel>>(await _tipoDespesaRepository.ObterTodos());
        }

        public async Task<List<TipoDespesa>> ObterTodosTeste()
        {
            return await _tipoDespesaRepository.ObterTodos();
        }

        public async Task RemoverAsync(Guid id)
        {
            await _tipoDespesaRepository.RemoverAsync(id);
        }
    }
}

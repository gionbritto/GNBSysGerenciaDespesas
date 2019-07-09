using AutoMapper;
using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Application.Interfaces;
using GNBSys.GerenciaDespesas.Application.ViewModels;
using GNBSys.GerenciaDespesas.Domain.Entities;
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

        public TipoDespesaAppService(GerenciaDespesaContext ctx)
        {
            _tipoDespesaRepository = new TipoDespesaRepository(ctx);
        }

        public async Task<TipoDespesaViewModel> Adicionar(TipoDespesaViewModel tipoDespesaViewModel)
        {
            var tipoDespesa = Mapper.Map<TipoDespesaViewModel, TipoDespesa>(tipoDespesaViewModel);

            await _tipoDespesaRepository.Adicionar(tipoDespesa);

            return tipoDespesaViewModel;
        }

        public async Task<TipoDespesaViewModel> Atualizar(TipoDespesaViewModel tipoDespesaViewModel)
        {
            await _tipoDespesaRepository.Atualizar(Mapper.Map<TipoDespesaViewModel, TipoDespesa>(tipoDespesaViewModel));
            return tipoDespesaViewModel;
        }


        public Task<TipoDespesaViewModel> Buscar(Expression<Func<TipoDespesaViewModel, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _tipoDespesaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<TipoDespesaViewModel> ObterPorId(Guid? id)
        {
            return Mapper.Map<TipoDespesa, TipoDespesaViewModel>(await _tipoDespesaRepository.ObterPorId(id));
        }

        public async Task<List<TipoDespesaViewModel>> ObterTodos()
        {
            return Mapper.Map<List<TipoDespesa>, List<TipoDespesaViewModel>>(await _tipoDespesaRepository.ObterTodos());
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

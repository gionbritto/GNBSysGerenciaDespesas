using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Domain.Entities;
using GNBSys.GerenciaDespesas.Application;
using AutoMapper;
using GNBSys.GerenciaDespesas.Application.ViewModels;

namespace GNBSys.GerenciaDespesas.UI.Mvc.Controllers
{
    public class DespesasController : Controller
    {
        private readonly DespesaAppService _despesaAppService;
        private readonly DadosGraficosAppService _dadosGraficosAppService;

        public DespesasController(GerenciaDespesaContext context, IMapper mapper)
        {
            _despesaAppService = new DespesaAppService(context, mapper);
            _dadosGraficosAppService = new DadosGraficosAppService(context);
        }

        public async Task<IActionResult> Index()
        {
            var meses = Task.Run(_despesaAppService.ObterMeses).Result;

            ViewData["Meses"] = new SelectList(meses.OrderBy(x => x.MesId), "MesId", "Nome");
            return View(await _despesaAppService.ObterTodos());
        }
        
        public IActionResult Create()
        {
            var meses = Task.Run(_despesaAppService.ObterMeses).Result;
            var tipoDespesas = Task.Run(_despesaAppService.ObterTipoDepesas).Result;
            ViewData["MesId"] = new SelectList(meses, "MesId", "Nome");
            ViewData["TipoDespesaId"] = new SelectList(tipoDespesas, "TipoDespesaId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DespesaId,TipoDespesaId,MesId,Valor")] DespesaViewModel despesa)
        {
            if (ModelState.IsValid)
            {
                var retorno = await _despesaAppService.Adicionar(despesa);
                if (retorno != null)
                {
                    TempData["Confirmacao"] = " Despesa cadastrada com sucesso!";
                }
                return RedirectToAction(nameof(Index));
            }
            var meses = Task.Run(_despesaAppService.ObterMeses).Result;
            var tipoDespesas = Task.Run(_despesaAppService.ObterTipoDepesas).Result;
            ViewData["MesId"] = new SelectList(meses, "MesId", "Nome");
            ViewData["TipoDespesaId"] = new SelectList(tipoDespesas, "TipoDespesaId", "Nome");
            return View(despesa);
        }

        // GET: Despesas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _despesaAppService.ObterPorId(id);
            if (despesa == null)
            {
                return NotFound();
            }
            var meses = Task.Run(_despesaAppService.ObterMeses).Result;
            var tipoDespesas = Task.Run(_despesaAppService.ObterTipoDepesas).Result;
            ViewData["MesId"] = new SelectList(meses, "MesId", "Nome");
            ViewData["TipoDespesaId"] = new SelectList(tipoDespesas, "TipoDespesaId", "Nome");
            return View(despesa);
        }

        // POST: Despesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DespesaId,TipoDespesaId,MesId,Valor")] DespesaViewModel despesa)
        {
            if (id != despesa.DespesaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var retorno = await _despesaAppService.Atualizar(despesa);

                    if (retorno != null)
                    {
                        TempData["Confirmacao"] = " Despesa atualizada com sucesso!";
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exits = await DespesaExists(despesa.DespesaId);

                    if (!exits)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var meses = Task.Run(_despesaAppService.ObterMeses).Result;
            var tipoDespesas = Task.Run(_despesaAppService.ObterTipoDepesas).Result;
            ViewData["MesId"] = new SelectList(meses, "MesId", "Nome");
            ViewData["TipoDespesaId"] = new SelectList(tipoDespesas, "TipoDespesaId", "Nome");
            return View(despesa);
        }

        // POST: Despesas/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {

            await _despesaAppService.RemoverAsync(id);

            TempData["Confirmacao"] = " Despesa excluída com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> DespesaExists(Guid id)
        {
            var depesaExists = await _despesaAppService.ObterPorId(id);
            if (depesaExists.DespesaId != null)
                return true;

            return false;
        }

        public JsonResult GastosTotaisMes(int ordem)
        {
            GastosTotaisMesViewModel gastos = new GastosTotaisMesViewModel();
            gastos = _despesaAppService.RetornarDadosGastosTotaisMes(ordem);
            //gastos.ValorTotalGasto = _context.TDespesa.Where(x => x.Mes.Ordem == ordem).Sum(x => x.Valor);
            //gastos.Salario = _context.TSalario.Where(x => x.Mes.Ordem == ordem).Select(x => x.Valor).FirstOrDefault();

            return Json(gastos);

        }

        //Graficos Donut
        public JsonResult GastosMes(int ordem)
        {
            var dados = _dadosGraficosAppService.RetornarDadosGastosMes(ordem);
            return Json(dados);
        }

        //Grafico de Linha
        public JsonResult GastosTotais()
        {
            var dados = _dadosGraficosAppService.RetornarDadosGraficoGastosTotais();
            return Json(dados);
        }
    }
}

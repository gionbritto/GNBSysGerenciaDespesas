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
    public class SalariosController : Controller
    {
        //private readonly GerenciaDespesaContext _context;
        private readonly SalarioAppService _salarioAppService;
        //private readonly IMapper _mapper;

        public SalariosController(GerenciaDespesaContext context, IMapper mapper)
        {
            _salarioAppService = new SalarioAppService(context, mapper);
        }

        // GET: Salarios
        public async Task<IActionResult> Index()
        {
            //var gerenciaDespesaContext = _context.TSalario.Include(s => s.Mes);
            return View(await _salarioAppService.ObterTodos());
        }

        // GET: Salarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var salario = await _context.TSalario
            //    .Include(s => s.Mes)
            //    .FirstOrDefaultAsync(m => m.SalarioId == id);
            var salario = await _salarioAppService.ObterPorId(id);
            if (salario == null)
            {
                return NotFound();
            }

            return View(salario);
        }

        // GET: Salarios/Create
        public IActionResult Create()
        {
            var meses = Task.Run(_salarioAppService.ObterMeses).Result;
            ViewData["MesId"] = new SelectList(meses, "MesId", "Nome");
            return View();
        }

        // POST: Salarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalarioId,Valor,MesId")] SalarioViewModel salario)
        {
            if (ModelState.IsValid)
            {
                //salario.SalarioId = Guid.NewGuid();
                await _salarioAppService.Adicionar(salario);
                TempData["Confirmacao"] = "Salário cadastrado com sucesso";
                return RedirectToAction(nameof(Index));
            }
            var meses = Task.Run(_salarioAppService.ObterMeses).Result;
            ViewData["MesId"] = new SelectList(meses, "MesId", "Nome");
            return View(salario);
        }

        // GET: Salarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salario = await _salarioAppService.ObterPorId(id);
            if (salario == null)
            {
                return NotFound();
            }
            var meses = Task.Run(_salarioAppService.ObterMeses).Result;
            ViewData["MesId"] = new SelectList(meses, "MesId", "Nome");

            return View(salario);
        }

        // POST: Salarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SalarioId,Valor,MesId")] SalarioViewModel salario)
        {
            if (id != salario.SalarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SalarioViewModel retorno;

                try
                {
                    retorno = await _salarioAppService.Atualizar(salario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exits = await SalarioExists(salario.SalarioId);

                    if (!exits)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                if(retorno != null)
                {
                    TempData["Confirmacao"] = "O salário foi atualizado com sucesso!";
                }

                return RedirectToAction(nameof(Index));
            }

            var meses = Task.Run(_salarioAppService.ObterMeses).Result;
            ViewData["MesId"] = new SelectList(meses, "MesId", "Nome");
            return View(salario);
        }

        //// GET: Salarios/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var salario = await _context.TSalario
        //        .Include(s => s.Mes)
        //        .FirstOrDefaultAsync(m => m.SalarioId == id);
        //    if (salario == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(salario);
        //}

        // POST: Salarios/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _salarioAppService.RemoverAsync(id);
            TempData["Confirmacao"] = "O salário foi excluído com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SalarioExists(Guid id)
        {
            var salarioExists = await _salarioAppService.ObterPorId(id);
            if (salarioExists.SalarioId != null)
                return true;

            return false;
        }
    }
}

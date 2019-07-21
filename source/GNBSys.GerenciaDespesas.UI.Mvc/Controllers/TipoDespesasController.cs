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
using GNBSys.GerenciaDespesas.Application.ViewModels;
using AutoMapper;

namespace GNBSys.GerenciaDespesas.UI.Mvc.Controllers
{
    public class TipoDespesasController : Controller
    {
        //private readonly GerenciaDespesaContext _context;
        private readonly TipoDespesaAppService _tipoDespesaAppService;
        private readonly IMapper _mapper;

        public TipoDespesasController(GerenciaDespesaContext context, IMapper mapper)
        {
            //_context = context;
            _tipoDespesaAppService = new TipoDespesaAppService(context, mapper);
            _mapper = mapper;
        }

        // GET: TipoDespesas
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //return View(await _context.TTipoDespesas.ToListAsync());
            //var tipoDespesaMapped = _mapper.Map<List<TipoDespesaViewModel>>();
            return View(await _tipoDespesaAppService.ObterTodos());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
            {
                return View(_tipoDespesaAppService.Buscar(x => x.Nome.ToUpper().Contains(txtProcurar.ToUpper())));
            }

            return View(await _tipoDespesaAppService.ObterTodos());

        }
        // GET: TipoDespesas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var tipoDespesa = await _context.TTipoDespesas
            //    .FirstOrDefaultAsync(m => m.TipoDespesaId == id);
            var tipoDespesa = await _tipoDespesaAppService.ObterPorId(id);
            if (tipoDespesa == null)
            {
                return NotFound();
            }

            return View(tipoDespesa);
        }

        // GET: TipoDespesas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDespesas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoDespesaId,Nome")] TipoDespesaViewModel tipoDespesaViewModel)
        {
            if (ModelState.IsValid)
            {
                //tipoDespesaViewModel.TipoDespesaId = Guid.NewGuid();
                var retorno = await _tipoDespesaAppService.Adicionar(tipoDespesaViewModel);
                
                if (retorno != null)
                {
                    TempData["Confirmacao"] = retorno.Nome + " foi cadastrado(a) com sucesso!";
                }
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDespesaViewModel);
        }

        // GET: TipoDespesas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var tipoDespesa = await _context.TTipoDespesas.FindAsync(id);
            var tipoDespesa = await _tipoDespesaAppService.ObterPorId(id);
            if (tipoDespesa == null)
            {
                return NotFound();
            }
            return View(tipoDespesa);
        }

        // POST: TipoDespesas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TipoDespesaId,Nome")] TipoDespesaViewModel tipoDespesaViewModel)
        {
            if (id != tipoDespesaViewModel.TipoDespesaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                TipoDespesaViewModel retorno;
                try
                {
                    retorno  = await _tipoDespesaAppService.Atualizar(tipoDespesaViewModel);
                    //await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exits = await TipoDespesaExists(tipoDespesaViewModel.TipoDespesaId);
                    if (!exits)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (retorno != null)
                {
                    TempData["Confirmacao"] = retorno.Nome + " foi atualizado(a) com sucesso!";
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDespesaViewModel);
        }

        //// GET: TipoDespesas/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tipoDespesa = await _context.TTipoDespesas
        //        .FirstOrDefaultAsync(m => m.TipoDespesaId == id);
        //    if (tipoDespesa == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tipoDespesa);
        //}

        // POST: TipoDespesas/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(Guid id)
        {
            //var tipoDespesa = await _tipoDespesaAppService.ObterPorId(id);
            await _tipoDespesaAppService.RemoverAsync(id);
            //await _context.SaveChangesAsync();
            return Json("Tipo despesa excluída com sucesso!");
        }

        private async Task<bool> TipoDespesaExists(Guid id)
        {
            var tipoDespesaExists = await _tipoDespesaAppService.ObterPorId(id);
            if (tipoDespesaExists.TipoDespesaId != null)
                return true;

            return false;
            //return _tipo.TTipoDespesas.Any(e => e.TipoDespesaId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GNBSsys.GerenciaDespesas.Infra.Data.Context;
using GNBSys.GerenciaDespesas.Domain.Entities.Receita;

namespace GNBSys.GerenciaDespesas.UI.Mvc.Controllers
{
    public class TiposAtivosController : Controller
    {
        private readonly GerenciaDespesaContext _context;

        public TiposAtivosController(GerenciaDespesaContext context)
        {
            _context = context;
        }

        // GET: TiposAtivos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TTipoAtivo.ToListAsync());
        }

        // GET: TiposAtivos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAtivo = await _context.TTipoAtivo
                .FirstOrDefaultAsync(m => m.TipoAtivoId == id);
            if (tipoAtivo == null)
            {
                return NotFound();
            }

            return View(tipoAtivo);
        }

        // GET: TiposAtivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposAtivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoAtivoId,Nome")] TipoAtivo tipoAtivo)
        {
            if (ModelState.IsValid)
            {
                tipoAtivo.TipoAtivoId = Guid.NewGuid();
                _context.Add(tipoAtivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAtivo);
        }

        // GET: TiposAtivos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAtivo = await _context.TTipoAtivo.FindAsync(id);
            if (tipoAtivo == null)
            {
                return NotFound();
            }
            return View(tipoAtivo);
        }

        // POST: TiposAtivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TipoAtivoId,Nome")] TipoAtivo tipoAtivo)
        {
            if (id != tipoAtivo.TipoAtivoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAtivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAtivoExists(tipoAtivo.TipoAtivoId))
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
            return View(tipoAtivo);
        }

        // GET: TiposAtivos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAtivo = await _context.TTipoAtivo
                .FirstOrDefaultAsync(m => m.TipoAtivoId == id);
            if (tipoAtivo == null)
            {
                return NotFound();
            }

            return View(tipoAtivo);
        }

        // POST: TiposAtivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tipoAtivo = await _context.TTipoAtivo.FindAsync(id);
            _context.TTipoAtivo.Remove(tipoAtivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAtivoExists(Guid id)
        {
            return _context.TTipoAtivo.Any(e => e.TipoAtivoId == id);
        }
    }
}

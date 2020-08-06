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
    public class TipoMovimentacoesCarteiraController : Controller
    {
        private readonly GerenciaDespesaContext _context;

        public TipoMovimentacoesCarteiraController(GerenciaDespesaContext context)
        {
            _context = context;
        }

        // GET: TipoMovimentacoesCarteira
        public async Task<IActionResult> Index()
        {
            return View(await _context.TTipoMovimentacaoCarteira.ToListAsync());
        }

        // GET: TipoMovimentacoesCarteira/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimentacaoCarteira = await _context.TTipoMovimentacaoCarteira
                .FirstOrDefaultAsync(m => m.TipoMovimentacaoCarteiraId == id);
            if (tipoMovimentacaoCarteira == null)
            {
                return NotFound();
            }

            return View(tipoMovimentacaoCarteira);
        }

        // GET: TipoMovimentacoesCarteira/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMovimentacoesCarteira/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoMovimentacaoCarteiraId,Nome")] TipoMovimentacaoCarteira tipoMovimentacaoCarteira)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMovimentacaoCarteira);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMovimentacaoCarteira);
        }

        // GET: TipoMovimentacoesCarteira/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimentacaoCarteira = await _context.TTipoMovimentacaoCarteira.FindAsync(id);
            if (tipoMovimentacaoCarteira == null)
            {
                return NotFound();
            }
            return View(tipoMovimentacaoCarteira);
        }

        // POST: TipoMovimentacoesCarteira/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoMovimentacaoCarteiraId,Nome")] TipoMovimentacaoCarteira tipoMovimentacaoCarteira)
        {
            if (id != tipoMovimentacaoCarteira.TipoMovimentacaoCarteiraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMovimentacaoCarteira);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMovimentacaoCarteiraExists(tipoMovimentacaoCarteira.TipoMovimentacaoCarteiraId))
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
            return View(tipoMovimentacaoCarteira);
        }

        // GET: TipoMovimentacoesCarteira/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMovimentacaoCarteira = await _context.TTipoMovimentacaoCarteira
                .FirstOrDefaultAsync(m => m.TipoMovimentacaoCarteiraId == id);
            if (tipoMovimentacaoCarteira == null)
            {
                return NotFound();
            }

            return View(tipoMovimentacaoCarteira);
        }

        // POST: TipoMovimentacoesCarteira/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMovimentacaoCarteira = await _context.TTipoMovimentacaoCarteira.FindAsync(id);
            _context.TTipoMovimentacaoCarteira.Remove(tipoMovimentacaoCarteira);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMovimentacaoCarteiraExists(int id)
        {
            return _context.TTipoMovimentacaoCarteira.Any(e => e.TipoMovimentacaoCarteiraId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trabalho_23_08.Models;

namespace Trabalho_23_08.Controllers
{
    public class AtendimentosController : Controller
    {
        private readonly Contexto _context;

        public AtendimentosController(Contexto context)
        {
            _context = context;
        }

        // GET: Atendimentos
        public async Task<IActionResult> Index()
        {
              return _context.atendimentos != null ? 
                          View(await _context.atendimentos.ToListAsync()) :
                          Problem("Entity set 'Contexto.atendimentos'  is null.");
        }

        // GET: Atendimentos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.atendimentos == null)
            {
                return NotFound();
            }

            var atendimento = await _context.atendimentos
                .FirstOrDefaultAsync(m => m.id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // GET: Atendimentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atendimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,data,hora")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atendimento);
        }

        // GET: Atendimentos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.atendimentos == null)
            {
                return NotFound();
            }

            var atendimento = await _context.atendimentos.FindAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            return View(atendimento);
        }

        // POST: Atendimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,data,hora")] Atendimento atendimento)
        {
            if (id != atendimento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentoExists(atendimento.id))
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
            return View(atendimento);
        }

        // GET: Atendimentos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.atendimentos == null)
            {
                return NotFound();
            }

            var atendimento = await _context.atendimentos
                .FirstOrDefaultAsync(m => m.id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // POST: Atendimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.atendimentos == null)
            {
                return Problem("Entity set 'Contexto.atendimentos'  is null.");
            }
            var atendimento = await _context.atendimentos.FindAsync(id);
            if (atendimento != null)
            {
                _context.atendimentos.Remove(atendimento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendimentoExists(long id)
        {
          return (_context.atendimentos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

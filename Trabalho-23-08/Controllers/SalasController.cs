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
    public class SalasController : Controller
    {
        private readonly Contexto _context;

        public SalasController(Contexto context)
        {
            _context = context;
        }

        // GET: Salas
        public async Task<IActionResult> Index()
        {
              return _context.salas != null ? 
                          View(await _context.salas.ToListAsync()) :
                          Problem("Entity set 'Contexto.salas'  is null.");
        }

        // GET: Salas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.salas == null)
            {
                return NotFound();
            }

            var sala = await _context.salas
                .FirstOrDefaultAsync(m => m.id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // GET: Salas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,equipamentos,situacao")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sala);
        }

        // GET: Salas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.salas == null)
            {
                return NotFound();
            }

            var sala = await _context.salas.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }
            return View(sala);
        }

        // POST: Salas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,descricao,equipamentos,situacao")] Sala sala)
        {
            if (id != sala.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaExists(sala.id))
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
            return View(sala);
        }

        // GET: Salas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.salas == null)
            {
                return NotFound();
            }

            var sala = await _context.salas
                .FirstOrDefaultAsync(m => m.id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.salas == null)
            {
                return Problem("Entity set 'Contexto.salas'  is null.");
            }
            var sala = await _context.salas.FindAsync(id);
            if (sala != null)
            {
                _context.salas.Remove(sala);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(long id)
        {
          return (_context.salas?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

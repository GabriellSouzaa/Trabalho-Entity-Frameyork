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
    public class CursoesController : Controller
    {
        private readonly Contexto _context;

        public CursoesController(Contexto context)
        {
            _context = context;
        }

        // GET: Cursoes
        public async Task<IActionResult> Index()
        {
              return _context.cursos != null ? 
                          View(await _context.cursos.ToListAsync()) :
                          Problem("Entity set 'Contexto.cursos'  is null.");
        }

        // GET: Cursoes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.cursos
                .FirstOrDefaultAsync(m => m.id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Cursoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: Cursoes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: Cursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,descricao")] Curso curso)
        {
            if (id != curso.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.id))
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
            return View(curso);
        }

        // GET: Cursoes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.cursos == null)
            {
                return NotFound();
            }

            var curso = await _context.cursos
                .FirstOrDefaultAsync(m => m.id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.cursos == null)
            {
                return Problem("Entity set 'Contexto.cursos'  is null.");
            }
            var curso = await _context.cursos.FindAsync(id);
            if (curso != null)
            {
                _context.cursos.Remove(curso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(long id)
        {
          return (_context.cursos?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}

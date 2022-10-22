using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ObjetosProjeto.Data;
using ObjetosProjeto.Models;

namespace ObjetosProjeto.Controllers
{
    public class ObjetosController : Controller
    {
        private readonly ObjetosProjetoContext _context;

        public ObjetosController(ObjetosProjetoContext context)
        {
            _context = context;
        }

        // GET: Objetos
        public async Task<IActionResult> Index()
        {
            var objetosProjetoContext = _context.ObjetoModel.Include(o => o.Contato);
            return View(await objetosProjetoContext.ToListAsync());
        }

        // GET: Objetos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ObjetoModel == null)
            {
                return NotFound();
            }

            var objetoModel = await _context.ObjetoModel
                .Include(o => o.Contato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objetoModel == null)
            {
                return NotFound();
            }

            return View(objetoModel);
        }

        // GET: Objetos/Create
        public IActionResult Create()
        {
            ViewData["ContatoId"] = new SelectList(_context.ContatoModel, "Id", "Celular");
            return View();
        }

        // POST: Objetos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ObjetoModel objetoModel)
        { 
        
            if (ModelState.IsValid)
            {
                _context.Add(objetoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContatoId"] = new SelectList(_context.ContatoModel, "Id", "Celular", objetoModel.ContatoId);
            return View(objetoModel);
        }

        // GET: Objetos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ObjetoModel == null)
            {
                return NotFound();
            }

            var objetoModel = await _context.ObjetoModel.FindAsync(id);
            if (objetoModel == null)
            {
                return NotFound();
            }
            ViewData["ContatoId"] = new SelectList(_context.ContatoModel, "Id", "Celular", objetoModel.ContatoId);
            return View(objetoModel);
        }

        // POST: Objetos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Objeto,Modelo,Detalhes,Localizacao,ContatoId")] ObjetoModel objetoModel)
        {
            if (id != objetoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objetoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjetoModelExists(objetoModel.Id))
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
            ViewData["ContatoId"] = new SelectList(_context.ContatoModel, "Id", "Celular", objetoModel.ContatoId);
            return View(objetoModel);
        }

        // GET: Objetos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ObjetoModel == null)
            {
                return NotFound();
            }

            var objetoModel = await _context.ObjetoModel
                .Include(o => o.Contato)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (objetoModel == null)
            {
                return NotFound();
            }

            return View(objetoModel);
        }

        // POST: Objetos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ObjetoModel == null)
            {
                return Problem("Entity set 'ObjetosProjetoContext.ObjetoModel'  is null.");
            }
            var objetoModel = await _context.ObjetoModel.FindAsync(id);
            if (objetoModel != null)
            {
                _context.ObjetoModel.Remove(objetoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObjetoModelExists(int id)
        {
          return _context.ObjetoModel.Any(e => e.Id == id);
        }
    }
}

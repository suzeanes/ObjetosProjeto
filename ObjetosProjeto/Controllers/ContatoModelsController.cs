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
    public class ContatoModelsController : Controller
    {
        private readonly ObjetosProjetoContext _context;

        public ContatoModelsController(ObjetosProjetoContext context)
        {
            _context = context;
        }

        // GET: ContatoModels
        public async Task<IActionResult> Index()
        {
              return View(await _context.ContatoModel.ToListAsync());
        }

        // GET: ContatoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ContatoModel == null)
            {
                return NotFound();
            }

            var contatoModel = await _context.ContatoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatoModel == null)
            {
                return NotFound();
            }

            return View(contatoModel);
        }

        // GET: ContatoModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContatoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Celular,dtn,genero,cep,endereco,numero,bairro,cidade,estado")] ContatoModel contatoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contatoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contatoModel);
        }

        // GET: ContatoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ContatoModel == null)
            {
                return NotFound();
            }

            var contatoModel = await _context.ContatoModel.FindAsync(id);
            if (contatoModel == null)
            {
                return NotFound();
            }
            return View(contatoModel);
        }

        // POST: ContatoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Celular,dtn,genero,cep,endereco,numero,bairro,cidade,estado")] ContatoModel contatoModel)
        {
            if (id != contatoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contatoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoModelExists(contatoModel.Id))
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
            return View(contatoModel);
        }

        // GET: ContatoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ContatoModel == null)
            {
                return NotFound();
            }

            var contatoModel = await _context.ContatoModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatoModel == null)
            {
                return NotFound();
            }

            return View(contatoModel);
        }

        // POST: ContatoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ContatoModel == null)
            {
                return Problem("Entity set 'ObjetosProjetoContext.ContatoModel'  is null.");
            }
            var contatoModel = await _context.ContatoModel.FindAsync(id);
            if (contatoModel != null)
            {
                _context.ContatoModel.Remove(contatoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoModelExists(int id)
        {
          return _context.ContatoModel.Any(e => e.Id == id);
        }
    }
}

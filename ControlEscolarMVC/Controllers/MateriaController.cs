using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlEscolarMVC.Models;

namespace ControlEscolarMVC.Controllers
{
    public class MateriaController : Controller
    {
        private readonly ControlEscolarReactMvcContext _context;

        public MateriaController(ControlEscolarReactMvcContext context)
        {
            _context = context;
        }

        // GET: Materia
        public async Task<IActionResult> Index()
        {
            var controlEscolarReactMvcContext = _context.Materia.Include(m => m.IdProfesorNavigation).Include(m => m.IdProgramaEstudioNavigation);
            return View(await controlEscolarReactMvcContext.ToListAsync());
        }

        // GET: Materia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materia = await _context.Materia
                .Include(m => m.IdProfesorNavigation)
                .Include(m => m.IdProgramaEstudioNavigation)
                .FirstOrDefaultAsync(m => m.IdMateria == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // GET: Materia/Create
        public IActionResult Create()
        {
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "Nombre");
            ViewData["IdProgramaEstudio"] = new SelectList(_context.ProgramaEstudios, "IdProgramaEstudio", "Nombre");
            return View();
        }

        // POST: Materia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMateria,ClaveMateria,Nombre,IdProfesor,IdProgramaEstudio,Estatus,FechaRegistro")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "Nombre", materia.IdProfesor);
            ViewData["IdProgramaEstudio"] = new SelectList(_context.ProgramaEstudios, "IdProgramaEstudio", "Nombre", materia.IdProgramaEstudio);
            return View(materia);
        }

        // GET: Materia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materia = await _context.Materia.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "Nombre", materia.IdProfesor);
            ViewData["IdProgramaEstudio"] = new SelectList(_context.ProgramaEstudios, "IdProgramaEstudio", "Nombre", materia.IdProgramaEstudio);
            return View(materia);
        }

        // POST: Materia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMateria,ClaveMateria,Nombre,IdProfesor,IdProgramaEstudio,Estatus,FechaRegistro")] Materia materia)
        {
            if (id != materia.IdMateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(materia.IdMateria))
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
            ViewData["IdProfesor"] = new SelectList(_context.Profesors, "IdProfesor", "IdProfesor", materia.IdProfesor);
            ViewData["IdProgramaEstudio"] = new SelectList(_context.ProgramaEstudios, "IdProgramaEstudio", "IdProgramaEstudio", materia.IdProgramaEstudio);
            return View(materia);
        }

        // GET: Materia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materia = await _context.Materia
                .Include(m => m.IdProfesorNavigation)
                .Include(m => m.IdProgramaEstudioNavigation)
                .FirstOrDefaultAsync(m => m.IdMateria == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // POST: Materia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Materia == null)
            {
                return Problem("Entity set 'ControlEscolarReactMvcContext.Materia'  is null.");
            }
            var materia = await _context.Materia.FindAsync(id);
            if (materia != null)
            {
                _context.Materia.Remove(materia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaExists(int id)
        {
          return (_context.Materia?.Any(e => e.IdMateria == id)).GetValueOrDefault();
        }
    }
}

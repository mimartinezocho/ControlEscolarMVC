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
    public class AlumnoMateriaController : Controller
    {
        private readonly ControlEscolarReactMvcContext _context;

        public AlumnoMateriaController(ControlEscolarReactMvcContext context)
        {
            _context = context;
        }

        // GET: AlumnoMateria
        public async Task<IActionResult> Index()
        {
            var controlEscolarReactMvcContext = _context.AlumnoMateria.Include(a => a.IdAlumnoNavigation).Include(a => a.IdMateriaNavigation);
            return View(await controlEscolarReactMvcContext.ToListAsync());
        }

        // GET: AlumnoMateria para Materias
        public async Task<IActionResult> IndexMateria(int? idMateria)
        {
            var controlEscolarReactMvcContext = _context.AlumnoMateria.Include(a => a.IdAlumnoNavigation).Include(a => a.IdMateriaNavigation);
            return View(await controlEscolarReactMvcContext.Where(x=>x.IdMateria==idMateria).ToListAsync());
        }

        // GET: AlumnoMateria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlumnoMateria == null)
            {
                return NotFound();
            }

            var alumnoMateria = await _context.AlumnoMateria
                .Include(a => a.IdAlumnoNavigation)
                .Include(a => a.IdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdAlumnoMateria == id);
            if (alumnoMateria == null)
            {
                return NotFound();
            }

            return View(alumnoMateria);
        }

        // GET: AlumnoMateria/Create
        public IActionResult Create()
        {
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "Nombre");
            ViewData["IdMateria"] = new SelectList(_context.Materia, "IdMateria", "Nombre");
            return View();
        }

        // POST: AlumnoMateria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlumnoMateria,IdMateria,IdAlumno,Progreso,Calificacion,Estatus,FechaRegistro")] AlumnoMateria alumnoMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnoMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "Nombre", alumnoMateria.IdAlumno);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "IdMateria", "Nombre", alumnoMateria.IdMateria);
            return View(alumnoMateria);
        }

        // GET: AlumnoMateria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlumnoMateria == null)
            {
                return NotFound();
            }

            var alumnoMateria = await _context.AlumnoMateria.FindAsync(id);
            if (alumnoMateria == null)
            {
                return NotFound();
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "Nombre", alumnoMateria.IdAlumno);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "IdMateria", "Nombre", alumnoMateria.IdMateria);
            return View(alumnoMateria);
        }

        // POST: AlumnoMateria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlumnoMateria,IdMateria,IdAlumno,Progreso,Calificacion,Estatus,FechaRegistro")] AlumnoMateria alumnoMateria)
        {
            if (id != alumnoMateria.IdAlumnoMateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnoMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoMateriaExists(alumnoMateria.IdAlumnoMateria))
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
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "IdAlumno", "IdAlumno", alumnoMateria.IdAlumno);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "IdMateria", "IdMateria", alumnoMateria.IdMateria);
            return View(alumnoMateria);
        }

        // GET: AlumnoMateria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlumnoMateria == null)
            {
                return NotFound();
            }

            var alumnoMateria = await _context.AlumnoMateria
                .Include(a => a.IdAlumnoNavigation)
                .Include(a => a.IdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdAlumnoMateria == id);
            if (alumnoMateria == null)
            {
                return NotFound();
            }

            return View(alumnoMateria);
        }

        // POST: AlumnoMateria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlumnoMateria == null)
            {
                return Problem("Entity set 'ControlEscolarReactMvcContext.AlumnoMateria'  is null.");
            }
            var alumnoMateria = await _context.AlumnoMateria.FindAsync(id);
            if (alumnoMateria != null)
            {
                _context.AlumnoMateria.Remove(alumnoMateria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoMateriaExists(int id)
        {
          return (_context.AlumnoMateria?.Any(e => e.IdAlumnoMateria == id)).GetValueOrDefault();
        }
    }
}

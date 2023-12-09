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
    public class ProfesorsController : Controller
    {
        private readonly ControlEscolarReactMvcContext _context;

        public ProfesorsController(ControlEscolarReactMvcContext context)
        {
            _context = context;
        }

        // GET: Profesors
        public async Task<IActionResult> Index()
        {
              return _context.Profesors != null ? 
                          View(await _context.Profesors.ToListAsync()) :
                          Problem("Entity set 'ControlEscolarReactMvcContext.Profesors'  is null.");
        }

        // GET: Profesors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profesors == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProfesor,Usuario,Nombre,Correo,Direccion,Telefono,Genero,Estatus,FechaRegistro")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profesor);
        }

        // GET: Profesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profesors == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        // POST: Profesors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProfesor,Usuario,Nombre,Correo,Direccion,Telefono,Genero,Estatus,FechaRegistro")] Profesor profesor)
        {
            if (id != profesor.IdProfesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesorExists(profesor.IdProfesor))
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
            return View(profesor);
        }

        // GET: Profesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profesors == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors
                .FirstOrDefaultAsync(m => m.IdProfesor == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // POST: Profesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profesors == null)
            {
                return Problem("Entity set 'ControlEscolarReactMvcContext.Profesors'  is null.");
            }
            var profesor = await _context.Profesors.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesors.Remove(profesor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
          return (_context.Profesors?.Any(e => e.IdProfesor == id)).GetValueOrDefault();
        }
    }
}

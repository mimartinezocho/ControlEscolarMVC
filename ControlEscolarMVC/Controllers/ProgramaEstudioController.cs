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
    public class ProgramaEstudioController : Controller
    {
        private readonly ControlEscolarReactMvcContext _context;

        public ProgramaEstudioController(ControlEscolarReactMvcContext context)
        {
            _context = context;
        }

        // GET: ProgramaEstudio
        public async Task<IActionResult> Index()
        {
            return _context.ProgramaEstudios != null ? 
                          View(await _context.ProgramaEstudios.ToListAsync()) :
                          Problem("Entity set 'ControlEscolarReactMvcContext.ProgramaEstudios'  is null.");
        }

        // GET: ProgramaEstudio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProgramaEstudios == null)
            {
                return NotFound();
            }

            var programaEstudio = await _context.ProgramaEstudios
                .FirstOrDefaultAsync(m => m.IdProgramaEstudio == id);
            if (programaEstudio == null)
            {
                return NotFound();
            }

            return View(programaEstudio);
        }

        // GET: ProgramaEstudio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramaEstudio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProgramaEstudio,Nombre,Descripcion,Estatus,FechaRegistro")] ProgramaEstudio programaEstudio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programaEstudio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programaEstudio);
        }

        // GET: ProgramaEstudio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProgramaEstudios == null)
            {
                return NotFound();
            }

            var programaEstudio = await _context.ProgramaEstudios.FindAsync(id);
            if (programaEstudio == null)
            {
                return NotFound();
            }
            return View(programaEstudio);
        }

        // POST: ProgramaEstudio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProgramaEstudio,Nombre,Descripcion,Estatus,FechaRegistro")] ProgramaEstudio programaEstudio)
        {
            if (id != programaEstudio.IdProgramaEstudio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programaEstudio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramaEstudioExists(programaEstudio.IdProgramaEstudio))
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
            return View(programaEstudio);
        }

        // GET: ProgramaEstudio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProgramaEstudios == null)
            {
                return NotFound();
            }

            var programaEstudio = await _context.ProgramaEstudios
                .FirstOrDefaultAsync(m => m.IdProgramaEstudio == id);
            if (programaEstudio == null)
            {
                return NotFound();
            }

            return View(programaEstudio);
        }

        // POST: ProgramaEstudio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProgramaEstudios == null)
            {
                return Problem("Entity set 'ControlEscolarReactMvcContext.ProgramaEstudios'  is null.");
            }
            var programaEstudio = await _context.ProgramaEstudios.FindAsync(id);
            if (programaEstudio != null)
            {
                _context.ProgramaEstudios.Remove(programaEstudio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramaEstudioExists(int id)
        {
          return (_context.ProgramaEstudios?.Any(e => e.IdProgramaEstudio == id)).GetValueOrDefault();
        }
    }
}

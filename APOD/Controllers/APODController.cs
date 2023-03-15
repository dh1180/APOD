using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APOD.Data;
using APOD.Models;

namespace APOD.Controllers
{
    public class APODController : Controller
    {
        private readonly APODContext _context;

        public APODController(APODContext context)
        {
            _context = context;
        }

        // GET: APODs
        public async Task<IActionResult> Index()
        {
              return _context.APOD != null ? 
                          View(await _context.APOD.ToListAsync()) :
                          Problem("Entity set 'APODContext.APOD'  is null.");
        }

        // GET: APODs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.APOD == null)
            {
                return NotFound();
            }

            var aPOD = await _context.APOD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aPOD == null)
            {
                return NotFound();
            }

            return View(aPOD);
        }

        // GET: APODs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: APODs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,date,explanation,hdurl")] APODModel aPOD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aPOD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aPOD);
        }

        // GET: APODs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.APOD == null)
            {
                return NotFound();
            }

            var aPOD = await _context.APOD.FindAsync(id);
            if (aPOD == null)
            {
                return NotFound();
            }
            return View(aPOD);
        }

        // POST: APODs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,date,explanation,hdurl")] APODModel aPOD)
        {
            if (id != aPOD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aPOD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!APODExists(aPOD.Id))
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
            return View(aPOD);
        }

        // GET: APODs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.APOD == null)
            {
                return NotFound();
            }

            var aPOD = await _context.APOD
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aPOD == null)
            {
                return NotFound();
            }

            return View(aPOD);
        }

        // POST: APODs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.APOD == null)
            {
                return Problem("Entity set 'APODContext.APOD'  is null.");
            }
            var aPOD = await _context.APOD.FindAsync(id);
            if (aPOD != null)
            {
                _context.APOD.Remove(aPOD);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool APODExists(int id)
        {
          return (_context.APOD?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EPB11.Data;
using EPB11.Models;
using Microsoft.AspNetCore.Authorization;

namespace EPB11.Controllers
{
    [Authorize]
    public class VenitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VenitController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Venit
        public async Task<IActionResult> Index()
        {
              return _context.Venit != null ? 
                          View(await _context.Venit.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Venit'  is null.");
        }

        // GET: Venit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Venit == null)
            {
                return NotFound();
            }

            var venitModel = await _context.Venit
                .FirstOrDefaultAsync(m => m.VenitId == id);
            if (venitModel == null)
            {
                return NotFound();
            }

            return View(venitModel);
        }

        // GET: Venit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Venit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VenitId,Denumire,Descriere,Sursa,Data,Suma,Moneda,SumaTotalaVenituri")] VenitModel venitModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venitModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(venitModel);
        }

        // GET: Venit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Venit == null)
            {
                return NotFound();
            }

            var venitModel = await _context.Venit.FindAsync(id);
            if (venitModel == null)
            {
                return NotFound();
            }
            return View(venitModel);
        }

        // POST: Venit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VenitId,Denumire,Descriere,Sursa,Data,Suma,Moneda,SumaTotalaVenituri")] VenitModel venitModel)
        {
            if (id != venitModel.VenitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venitModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VenitModelExists(venitModel.VenitId))
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
            return View(venitModel);
        }

        // GET: Venit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Venit == null)
            {
                return NotFound();
            }

            var venitModel = await _context.Venit
                .FirstOrDefaultAsync(m => m.VenitId == id);
            if (venitModel == null)
            {
                return NotFound();
            }

            return View(venitModel);
        }

        // POST: Venit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Venit == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Venit'  is null.");
            }
            var venitModel = await _context.Venit.FindAsync(id);
            if (venitModel != null)
            {
                _context.Venit.Remove(venitModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VenitModelExists(int id)
        {
          return (_context.Venit?.Any(e => e.VenitId == id)).GetValueOrDefault();
        }
    }
}

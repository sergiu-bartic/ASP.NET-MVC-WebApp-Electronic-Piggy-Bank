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
    public class SoldController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SoldController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sold
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sold.Include(s => s.achizitie).Include(s => s.venit);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sold/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sold == null)
            {
                return NotFound();
            }

            var soldModel = await _context.Sold
                .Include(s => s.achizitie)
                .Include(s => s.venit)
                .FirstOrDefaultAsync(m => m.SoldId == id);
            if (soldModel == null)
            {
                return NotFound();
            }

            return View(soldModel);
        }

        // GET: Sold/Create
        public IActionResult Create()
        {
            ViewData["AchizitieId"] = new SelectList(_context.Achizitie, "AchizitieId", "SumaTotalaAchizitii");
            ViewData["VenitId"] = new SelectList(_context.Venit, "VenitId", "SumaTotalaVenituri");
            return View();
        }

        // POST: Sold/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoldId,VenitId,AchizitieId,Sold,Moneda")] SoldModel soldModel)
        {
            
                _context.Add(soldModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["AchizitieId"] = new SelectList(_context.Achizitie, "AchizitieId", "SumaTotalaAchizitii", soldModel.AchizitieId);
            ViewData["VenitId"] = new SelectList(_context.Venit, "VenitId", "SumaTotalaVenituri", soldModel.VenitId);
            return View(soldModel);
        }

        // GET: Sold/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sold == null)
            {
                return NotFound();
            }

            var soldModel = await _context.Sold.FindAsync(id);
            if (soldModel == null)
            {
                return NotFound();
            }
            ViewData["AchizitieId"] = new SelectList(_context.Achizitie, "AchizitieId", "SumaTotalaAchizitii", soldModel.AchizitieId);
            ViewData["VenitId"] = new SelectList(_context.Venit, "VenitId", "SumaTotalaVenituri", soldModel.VenitId);
            return View(soldModel);
        }

        // POST: Sold/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoldId,VenitId,AchizitieId,Sold,Moneda")] SoldModel soldModel)
        {
            if (id != soldModel.SoldId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(soldModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoldModelExists(soldModel.SoldId))
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
            ViewData["AchizitieId"] = new SelectList(_context.Achizitie, "AchizitieId", "SumaTotalaAchizitii", soldModel.AchizitieId);
            ViewData["VenitId"] = new SelectList(_context.Venit, "VenitId", "SumaTotalaVenituri", soldModel.VenitId);
            return View(soldModel);
        }

        // GET: Sold/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sold == null)
            {
                return NotFound();
            }

            var soldModel = await _context.Sold
                .Include(s => s.achizitie)
                .Include(s => s.venit)
                .FirstOrDefaultAsync(m => m.SoldId == id);
            if (soldModel == null)
            {
                return NotFound();
            }

            return View(soldModel);
        }

        // POST: Sold/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sold == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sold'  is null.");
            }
            var soldModel = await _context.Sold.FindAsync(id);
            if (soldModel != null)
            {
                _context.Sold.Remove(soldModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoldModelExists(int id)
        {
          return (_context.Sold?.Any(e => e.SoldId == id)).GetValueOrDefault();
        }
    }
}

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
    public class AchizitieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AchizitieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Achizitie
        public async Task<IActionResult> Index()
        {
              return _context.Achizitie != null ? 
                          View(await _context.Achizitie.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Achizitie'  is null.");
        }

        // GET: Achizitie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Achizitie == null)
            {
                return NotFound();
            }

            var achizitieModel = await _context.Achizitie
                .FirstOrDefaultAsync(m => m.AchizitieId == id);
            if (achizitieModel == null)
            {
                return NotFound();
            }

            return View(achizitieModel);
        }

        // GET: Achizitie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Achizitie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AchizitieId,Denumire,Descriere,OfflineOnline,Locatie,Unitate,PretPerUnitate,PretTotal,Moneda,Data,SumaTotalaAchizitii")] AchizitieModel achizitieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(achizitieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(achizitieModel);
        }

        // GET: Achizitie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Achizitie == null)
            {
                return NotFound();
            }

            var achizitieModel = await _context.Achizitie.FindAsync(id);
            if (achizitieModel == null)
            {
                return NotFound();
            }
            return View(achizitieModel);
        }

        // POST: Achizitie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AchizitieId,Denumire,Descriere,OfflineOnline,Locatie,Unitate,PretPerUnitate,PretTotal,Moneda,Data,SumaTotalaAchizitii")] AchizitieModel achizitieModel)
        {
            if (id != achizitieModel.AchizitieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achizitieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchizitieModelExists(achizitieModel.AchizitieId))
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
            return View(achizitieModel);
        }

        // GET: Achizitie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Achizitie == null)
            {
                return NotFound();
            }

            var achizitieModel = await _context.Achizitie
                .FirstOrDefaultAsync(m => m.AchizitieId == id);
            if (achizitieModel == null)
            {
                return NotFound();
            }

            return View(achizitieModel);
        }

        // POST: Achizitie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Achizitie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Achizitie'  is null.");
            }
            var achizitieModel = await _context.Achizitie.FindAsync(id);
            if (achizitieModel != null)
            {
                _context.Achizitie.Remove(achizitieModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchizitieModelExists(int id)
        {
          return (_context.Achizitie?.Any(e => e.AchizitieId == id)).GetValueOrDefault();
        }
    }
}

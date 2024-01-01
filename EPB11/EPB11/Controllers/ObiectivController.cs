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
    public class ObiectivController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ObiectivController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Obiectiv
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Obiectiv.Include(o => o.sold);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Obiectiv/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Obiectiv == null)
            {
                return NotFound();
            }

            var obiectivModel = await _context.Obiectiv
                .Include(o => o.sold)
                .FirstOrDefaultAsync(m => m.ObiectivId == id);
            if (obiectivModel == null)
            {
                return NotFound();
            }

            return View(obiectivModel);
        }

        // GET: Obiectiv/Create
        public IActionResult Create()
        {
            ViewData["SoldId"] = new SelectList(_context.Sold, "SoldId", "Sold");
            return View();
        }

        // POST: Obiectiv/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObiectivId,Denumire,Descriere,Unitate,PretPerUnitate,SumaTotala,SoldId,SumaDeStrans,Moneda,Data,TimpRamas,SumaPerTimp,OfflineOnline,Locatie")] ObiectivModel obiectivModel)
        {
            
                _context.Add(obiectivModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["SoldId"] = new SelectList(_context.Sold, "SoldId", "Sold", obiectivModel.SoldId);
            return View(obiectivModel);
        }

        // GET: Obiectiv/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Obiectiv == null)
            {
                return NotFound();
            }

            var obiectivModel = await _context.Obiectiv.FindAsync(id);
            if (obiectivModel == null)
            {
                return NotFound();
            }
            ViewData["SoldId"] = new SelectList(_context.Sold, "SoldId", "Sold", obiectivModel.SoldId);
            return View(obiectivModel);
        }

        // POST: Obiectiv/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObiectivId,Denumire,Descriere,Unitate,PretPerUnitate,SumaTotala,SoldId,SumaDeStrans,Moneda,Data,TimpRamas,SumaPerTimp,OfflineOnline,Locatie")] ObiectivModel obiectivModel)
        {
            if (id != obiectivModel.ObiectivId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obiectivModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObiectivModelExists(obiectivModel.ObiectivId))
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
            ViewData["SoldId"] = new SelectList(_context.Sold, "SoldId", "Sold", obiectivModel.SoldId);
            return View(obiectivModel);
        }

        // GET: Obiectiv/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Obiectiv == null)
            {
                return NotFound();
            }

            var obiectivModel = await _context.Obiectiv
                .Include(o => o.sold)
                .FirstOrDefaultAsync(m => m.ObiectivId == id);
            if (obiectivModel == null)
            {
                return NotFound();
            }

            return View(obiectivModel);
        }

        // POST: Obiectiv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Obiectiv == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Obiectiv'  is null.");
            }
            var obiectivModel = await _context.Obiectiv.FindAsync(id);
            if (obiectivModel != null)
            {
                _context.Obiectiv.Remove(obiectivModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObiectivModelExists(int id)
        {
          return (_context.Obiectiv?.Any(e => e.ObiectivId == id)).GetValueOrDefault();
        }
    }
}

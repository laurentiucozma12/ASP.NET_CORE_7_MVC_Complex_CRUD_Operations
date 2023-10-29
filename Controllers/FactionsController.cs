using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Learn_ASP.NET_CRUD.Data;
using Learn_ASP.NET_CRUD.Models;

namespace Learn_ASP.NET_CRUD.Controllers
{
    public class FactionsController : Controller
    {
        private readonly DataContext _context;

        public FactionsController(DataContext context)
        {
            _context = context;
        }

        // GET: Factions
        public async Task<IActionResult> Index()
        {
              return _context.Factions != null ? 
                          View(await _context.Factions.ToListAsync()) :
                          Problem("Entity set 'DataContext.Factions'  is null.");
        }

        // GET: Factions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Factions == null)
            {
                return NotFound();
            }

            var faction = await _context.Factions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faction == null)
            {
                return NotFound();
            }

            return View(faction);
        }

        // GET: Factions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Factions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Faction faction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faction);
        }

        // GET: Factions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Factions == null)
            {
                return NotFound();
            }

            var faction = await _context.Factions.FindAsync(id);
            if (faction == null)
            {
                return NotFound();
            }
            return View(faction);
        }

        // POST: Factions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Faction faction)
        {
            if (id != faction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FactionExists(faction.Id))
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
            return View(faction);
        }

        // GET: Factions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Factions == null)
            {
                return NotFound();
            }

            var faction = await _context.Factions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faction == null)
            {
                return NotFound();
            }

            return View(faction);
        }

        // POST: Factions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Factions == null)
            {
                return Problem("Entity set 'DataContext.Factions'  is null.");
            }
            var faction = await _context.Factions.FindAsync(id);
            if (faction != null)
            {
                _context.Factions.Remove(faction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FactionExists(int id)
        {
          return (_context.Factions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

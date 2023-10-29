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
    public class BackpacksController : Controller
    {
        private readonly DataContext _context;

        public BackpacksController(DataContext context)
        {
            _context = context;
        }

        // GET: Backpacks
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Backpacks.Include(b => b.Character);
            return View(await dataContext.ToListAsync());
        }

        // GET: Backpacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Backpacks == null)
            {
                return NotFound();
            }

            var backpack = await _context.Backpacks
                .Include(b => b.Character)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (backpack == null)
            {
                return NotFound();
            }

            return View(backpack);
        }

        // GET: Backpacks/Create
        public IActionResult Create()
        {
            ViewData["CharacterId"] = new SelectList(_context.Characters, "Id", "Id");
            return View();
        }

        // POST: Backpacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Backpack backpack)
        {
            if (ModelState.IsValid)
            {
                // The backpack is not assigned to a character 
                _context.Add(backpack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(backpack);
        }

        // GET: Backpacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var backpack = await _context.Backpacks.FindAsync(id);
            if (backpack == null)
            {
                return NotFound();
            }

            return View(backpack);
        }

        // POST: Backpacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Backpack backpack)
        {
            if (id != backpack.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the current backpack
                    var currentBackpack = await _context.Backpacks.FindAsync(id);
                    currentBackpack.Name = backpack.Name; // Update the name

                    _context.Update(currentBackpack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BackpackExists(backpack.Id))
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

            return View(backpack);
        }

        // GET: Backpacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Backpacks == null)
            {
                return NotFound();
            }

            var backpack = await _context.Backpacks
                .Include(b => b.Character)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (backpack == null)
            {
                return NotFound();
            }

            return View(backpack);
        }

        // POST: Backpacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Backpacks == null)
            {
                return Problem("Entity set 'DataContext.Backpacks'  is null.");
            }
            var backpack = await _context.Backpacks.FindAsync(id);
            if (backpack != null)
            {
                _context.Backpacks.Remove(backpack);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BackpackExists(int id)
        {
          return (_context.Backpacks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrewLog.Data;
using BrewLog.Models;

namespace BrewLog.Controllers
{
    public class FermentablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FermentablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Fermentables
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fermentables.ToListAsync());
        }

        // GET: Fermentables/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fermentable = await _context.Fermentables
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fermentable == null)
            {
                return NotFound();
            }

            return View(fermentable);
        }

        // GET: Fermentables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fermentables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Version,Amount,Color,AddAfterBoil,Notes")] Fermentable fermentable)
        {
            if (ModelState.IsValid)
            {
                fermentable.Id = Guid.NewGuid();
                _context.Add(fermentable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fermentable);
        }

        // GET: Fermentables/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fermentable = await _context.Fermentables.SingleOrDefaultAsync(m => m.Id == id);
            if (fermentable == null)
            {
                return NotFound();
            }
            return View(fermentable);
        }

        // POST: Fermentables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Version,Amount,Color,AddAfterBoil,Notes")] Fermentable fermentable)
        {
            if (id != fermentable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fermentable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FermentableExists(fermentable.Id))
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
            return View(fermentable);
        }

        // GET: Fermentables/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fermentable = await _context.Fermentables
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fermentable == null)
            {
                return NotFound();
            }

            return View(fermentable);
        }

        // POST: Fermentables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fermentable = await _context.Fermentables.SingleOrDefaultAsync(m => m.Id == id);
            _context.Fermentables.Remove(fermentable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FermentableExists(Guid id)
        {
            return _context.Fermentables.Any(e => e.Id == id);
        }
    }
}

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
    public class FermentableTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FermentableTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FermentableTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FermentableTypes.ToListAsync());
        }

        // GET: FermentableTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fermentableType = await _context.FermentableTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fermentableType == null)
            {
                return NotFound();
            }

            return View(fermentableType);
        }

        // GET: FermentableTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FermentableTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] FermentableType fermentableType)
        {
            if (ModelState.IsValid)
            {
                fermentableType.Id = Guid.NewGuid();
                _context.Add(fermentableType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fermentableType);
        }

        // GET: FermentableTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fermentableType = await _context.FermentableTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (fermentableType == null)
            {
                return NotFound();
            }
            return View(fermentableType);
        }

        // POST: FermentableTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Type")] FermentableType fermentableType)
        {
            if (id != fermentableType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fermentableType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FermentableTypeExists(fermentableType.Id))
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
            return View(fermentableType);
        }

        // GET: FermentableTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fermentableType = await _context.FermentableTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (fermentableType == null)
            {
                return NotFound();
            }

            return View(fermentableType);
        }

        // POST: FermentableTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fermentableType = await _context.FermentableTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.FermentableTypes.Remove(fermentableType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FermentableTypeExists(Guid id)
        {
            return _context.FermentableTypes.Any(e => e.Id == id);
        }
    }
}

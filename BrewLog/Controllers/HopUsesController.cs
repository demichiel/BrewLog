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
    public class HopUsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HopUsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HopUses
        public async Task<IActionResult> Index()
        {
            return View(await _context.HopUses.ToListAsync());
        }

        // GET: HopUses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopUse = await _context.HopUses
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hopUse == null)
            {
                return NotFound();
            }

            return View(hopUse);
        }

        // GET: HopUses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HopUses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Use")] HopUse hopUse)
        {
            if (ModelState.IsValid)
            {
                hopUse.Id = Guid.NewGuid();
                _context.Add(hopUse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hopUse);
        }

        // GET: HopUses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopUse = await _context.HopUses.SingleOrDefaultAsync(m => m.Id == id);
            if (hopUse == null)
            {
                return NotFound();
            }
            return View(hopUse);
        }

        // POST: HopUses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Use")] HopUse hopUse)
        {
            if (id != hopUse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopUse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopUseExists(hopUse.Id))
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
            return View(hopUse);
        }

        // GET: HopUses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopUse = await _context.HopUses
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hopUse == null)
            {
                return NotFound();
            }

            return View(hopUse);
        }

        // POST: HopUses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var hopUse = await _context.HopUses.SingleOrDefaultAsync(m => m.Id == id);
            _context.HopUses.Remove(hopUse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopUseExists(Guid id)
        {
            return _context.HopUses.Any(e => e.Id == id);
        }
    }
}

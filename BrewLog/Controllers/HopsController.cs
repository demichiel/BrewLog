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
    public class HopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hops
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hops.ToListAsync());
        }

        // GET: Hops/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hop = await _context.Hops
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hop == null)
            {
                return NotFound();
            }

            return View(hop);
        }

        // GET: Hops/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Version,Alpha,Amount,Minutes,Notes,Beta")] Hop hop)
        {
            if (ModelState.IsValid)
            {
                hop.Id = Guid.NewGuid();
                _context.Add(hop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hop);
        }

        // GET: Hops/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hop = await _context.Hops.SingleOrDefaultAsync(m => m.Id == id);
            if (hop == null)
            {
                return NotFound();
            }
            return View(hop);
        }

        // POST: Hops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Version,Alpha,Amount,Minutes,Notes,Beta")] Hop hop)
        {
            if (id != hop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopExists(hop.Id))
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
            return View(hop);
        }

        // GET: Hops/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hop = await _context.Hops
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hop == null)
            {
                return NotFound();
            }

            return View(hop);
        }

        // POST: Hops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var hop = await _context.Hops.SingleOrDefaultAsync(m => m.Id == id);
            _context.Hops.Remove(hop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopExists(Guid id)
        {
            return _context.Hops.Any(e => e.Id == id);
        }
    }
}

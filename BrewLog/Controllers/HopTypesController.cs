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
    public class HopTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HopTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HopTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.HopTypes.ToListAsync());
        }

        // GET: HopTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopType = await _context.HopTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hopType == null)
            {
                return NotFound();
            }

            return View(hopType);
        }

        // GET: HopTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HopTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] HopType hopType)
        {
            if (ModelState.IsValid)
            {
                hopType.Id = Guid.NewGuid();
                _context.Add(hopType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hopType);
        }

        // GET: HopTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopType = await _context.HopTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (hopType == null)
            {
                return NotFound();
            }
            return View(hopType);
        }

        // POST: HopTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Type")] HopType hopType)
        {
            if (id != hopType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopTypeExists(hopType.Id))
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
            return View(hopType);
        }

        // GET: HopTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopType = await _context.HopTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hopType == null)
            {
                return NotFound();
            }

            return View(hopType);
        }

        // POST: HopTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var hopType = await _context.HopTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.HopTypes.Remove(hopType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopTypeExists(Guid id)
        {
            return _context.HopTypes.Any(e => e.Id == id);
        }
    }
}

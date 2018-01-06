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
    public class YeastTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YeastTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YeastTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.YeastTypes.ToListAsync());
        }

        // GET: YeastTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeastType = await _context.YeastTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (yeastType == null)
            {
                return NotFound();
            }

            return View(yeastType);
        }

        // GET: YeastTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YeastTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type")] YeastType yeastType)
        {
            if (ModelState.IsValid)
            {
                yeastType.Id = Guid.NewGuid();
                _context.Add(yeastType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yeastType);
        }

        // GET: YeastTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeastType = await _context.YeastTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (yeastType == null)
            {
                return NotFound();
            }
            return View(yeastType);
        }

        // POST: YeastTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Type")] YeastType yeastType)
        {
            if (id != yeastType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yeastType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YeastTypeExists(yeastType.Id))
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
            return View(yeastType);
        }

        // GET: YeastTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeastType = await _context.YeastTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (yeastType == null)
            {
                return NotFound();
            }

            return View(yeastType);
        }

        // POST: YeastTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var yeastType = await _context.YeastTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.YeastTypes.Remove(yeastType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YeastTypeExists(Guid id)
        {
            return _context.YeastTypes.Any(e => e.Id == id);
        }
    }
}

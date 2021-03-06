﻿using System;
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
    public class YeastsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YeastsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yeasts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yeasts.ToListAsync());
        }

        // GET: Yeasts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeast = await _context.Yeasts
                .SingleOrDefaultAsync(m => m.Id == id);
            if (yeast == null)
            {
                return NotFound();
            }

            return View(yeast);
        }

        // GET: Yeasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yeasts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AmountIsWeight")] Yeast yeast)
        {
            if (ModelState.IsValid)
            {
                yeast.Id = Guid.NewGuid();
                _context.Add(yeast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yeast);
        }

        // GET: Yeasts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeast = await _context.Yeasts.SingleOrDefaultAsync(m => m.Id == id);
            if (yeast == null)
            {
                return NotFound();
            }
            return View(yeast);
        }

        // POST: Yeasts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,AmountIsWeight")] Yeast yeast)
        {
            if (id != yeast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yeast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YeastExists(yeast.Id))
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
            return View(yeast);
        }

        // GET: Yeasts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeast = await _context.Yeasts
                .SingleOrDefaultAsync(m => m.Id == id);
            if (yeast == null)
            {
                return NotFound();
            }

            return View(yeast);
        }

        // POST: Yeasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var yeast = await _context.Yeasts.SingleOrDefaultAsync(m => m.Id == id);
            _context.Yeasts.Remove(yeast);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YeastExists(Guid id)
        {
            return _context.Yeasts.Any(e => e.Id == id);
        }
    }
}

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
    public class HopFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HopFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HopForms
        public async Task<IActionResult> Index()
        {
            return View(await _context.HopForms.ToListAsync());
        }

        // GET: HopForms/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopForm = await _context.HopForms
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hopForm == null)
            {
                return NotFound();
            }

            return View(hopForm);
        }

        // GET: HopForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HopForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Form")] HopForm hopForm)
        {
            if (ModelState.IsValid)
            {
                hopForm.Id = Guid.NewGuid();
                _context.Add(hopForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hopForm);
        }

        // GET: HopForms/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopForm = await _context.HopForms.SingleOrDefaultAsync(m => m.Id == id);
            if (hopForm == null)
            {
                return NotFound();
            }
            return View(hopForm);
        }

        // POST: HopForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Form")] HopForm hopForm)
        {
            if (id != hopForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopFormExists(hopForm.Id))
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
            return View(hopForm);
        }

        // GET: HopForms/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopForm = await _context.HopForms
                .SingleOrDefaultAsync(m => m.Id == id);
            if (hopForm == null)
            {
                return NotFound();
            }

            return View(hopForm);
        }

        // POST: HopForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var hopForm = await _context.HopForms.SingleOrDefaultAsync(m => m.Id == id);
            _context.HopForms.Remove(hopForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopFormExists(Guid id)
        {
            return _context.HopForms.Any(e => e.Id == id);
        }
    }
}

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
    public class YeastFormsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YeastFormsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: YeastForms
        public async Task<IActionResult> Index()
        {
            return View(await _context.YeastForms.ToListAsync());
        }

        // GET: YeastForms/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeastForm = await _context.YeastForms
                .SingleOrDefaultAsync(m => m.Id == id);
            if (yeastForm == null)
            {
                return NotFound();
            }

            return View(yeastForm);
        }

        // GET: YeastForms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YeastForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Form")] YeastForm yeastForm)
        {
            if (ModelState.IsValid)
            {
                yeastForm.Id = Guid.NewGuid();
                _context.Add(yeastForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yeastForm);
        }

        // GET: YeastForms/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeastForm = await _context.YeastForms.SingleOrDefaultAsync(m => m.Id == id);
            if (yeastForm == null)
            {
                return NotFound();
            }
            return View(yeastForm);
        }

        // POST: YeastForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Form")] YeastForm yeastForm)
        {
            if (id != yeastForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yeastForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YeastFormExists(yeastForm.Id))
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
            return View(yeastForm);
        }

        // GET: YeastForms/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yeastForm = await _context.YeastForms
                .SingleOrDefaultAsync(m => m.Id == id);
            if (yeastForm == null)
            {
                return NotFound();
            }

            return View(yeastForm);
        }

        // POST: YeastForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var yeastForm = await _context.YeastForms.SingleOrDefaultAsync(m => m.Id == id);
            _context.YeastForms.Remove(yeastForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YeastFormExists(Guid id)
        {
            return _context.YeastForms.Any(e => e.Id == id);
        }
    }
}

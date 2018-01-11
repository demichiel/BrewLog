using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrewLog.Data;
using BrewLog.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Xml;
using System.Globalization;

namespace BrewLog.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recipes.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipes = await _context.Recipes
                .Include(recipe => recipe.Hops)
                .Include(recipe => recipe.Fermentables)
                .Include(recipe => recipe.Yeasts)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (recipes == null)
            {
                return NotFound();
            }

            return View(recipes);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Recipes/Import
        public IActionResult Import()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Version,Brewery,Volume,BoilSize,BoilTime,Efficiency,Notes,OriginalGravity,FinalGravity,Date")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                recipe.Id = Guid.NewGuid();
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes.SingleOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Version,Brewery,Volume,BoilSize,BoilTime,Efficiency,Notes,OriginalGravity,FinalGravity,Date")] Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.Id))
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
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var recipe = await _context.Recipes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(Guid id)
        {
            return _context.Recipes.Any(e => e.Id == id);
        }


        [HttpPost, ActionName("Import")]
        public async Task<IActionResult> Import(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                    await ImportFileToRecipe(formFile.OpenReadStream());
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ImportFileToRecipe(Stream stream)
        {
            XmlDocument doc = new XmlDocument();
            if (stream.Position > 0)
            {
                stream.Position = 0;
            }
            doc.Load(stream);
            Recipe recipe = new Recipe();
            recipe.Id = Guid.NewGuid();
            _context.Add(recipe);
            await _context.SaveChangesAsync();
            XmlNodeList xnList = doc.SelectNodes("RECIPES/RECIPE");
            recipe.Name = xnList[0]["NAME"].InnerText;
            recipe.Brewery = xnList[0]["BREWER"].InnerText;
            recipe.Volume = double.Parse(xnList[0]["BATCH_SIZE"].InnerText, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"));
            recipe.Efficiency = double.Parse(xnList[0]["EFFICIENCY"].InnerText, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"));
            string boilTime = xnList[0]["BOIL_TIME"].InnerText;
            boilTime = boilTime.Substring(0, boilTime.IndexOf('.'));
            recipe.BoilTime = int.Parse(boilTime);
            recipe.BoilSize = double.Parse(xnList[0]["BOIL_SIZE"].InnerText, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"));
            recipe.Color = xnList[0]["EST_COLOR"].InnerText;
            recipe.OriginalGravity = xnList[0]["EST_OG"].InnerText;
            recipe.FinalGravity = xnList[0]["EST_FG"].InnerText;
            recipe.IBU = xnList[0]["IBU"].InnerText;
            recipe.ABV = xnList[0]["EST_ABV"].InnerText;
            recipe.Notes = xnList[0]["NOTES"].InnerText;
            recipe.Date = DateTime.Now;
            await _context.SaveChangesAsync();

            // Load all hops
            xnList = doc.SelectNodes("RECIPES/RECIPE/HOPS/HOP");
            recipe.Hops = new List<Hop>();
            foreach (XmlNode node in xnList)
            {
                Hop hop = new Hop();
                hop.Alpha = double.Parse(node["ALPHA"].InnerText, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"));
                hop.Amount = double.Parse(node["AMOUNT"].InnerText, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"));
                string minutes = node["TIME"].InnerText;
                minutes = minutes.Substring(0, minutes.IndexOf('.'));
                hop.Minutes = int.Parse(minutes);
                hop.Name = node["NAME"].InnerText;
                hop.DisplayAmount = node["DISPLAY_AMOUNT"].InnerText;
                hop.DisplayTime = node["DISPLAY_TIME"].InnerText;
                hop.Type = node["TYPE"].InnerText;
                hop.Use = node["USE"].InnerText;
                recipe.Hops.Add(hop);
                await _context.SaveChangesAsync();
            }

            // Load all fermentables
            xnList = doc.SelectNodes("RECIPES/RECIPE/FERMENTABLES/FERMENTABLE");
            recipe.Fermentables = new List<Fermentable>();
            foreach (XmlNode node in xnList)
            {
                Fermentable fermentable = new Fermentable();
                fermentable.Name = node["NAME"].InnerText;
                fermentable.Type = node["TYPE"].InnerText;
                fermentable.Amount = double.Parse(node["AMOUNT"].InnerText, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"));
                fermentable.Color = float.Parse(node["AMOUNT"].InnerText, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"));
                fermentable.Notes = node["NOTES"].InnerText;
                fermentable.DisplayAmount = node["DISPLAY_AMOUNT"].InnerText;
                fermentable.DisplayColor = node["DISPLAY_COLOR"].InnerText;
                recipe.Fermentables.Add(fermentable);
                await _context.SaveChangesAsync();
            }

            // Load all yeasts
            xnList = doc.SelectNodes("RECIPES/RECIPE/YEASTS/YEAST");
            recipe.Yeasts = new List<Yeast>();
            foreach (XmlNode node in xnList)
            {
                Yeast yeast = new Yeast();
                yeast.Name = node["NAME"].InnerText;
                yeast.Type = node["TYPE"].InnerText;
                yeast.Form = node["FORM"].InnerText;
                yeast.Notes = node["NOTES"].InnerText;
                yeast.ProductID = node["PRODUCT_ID"].InnerText;
                yeast.Laboratory = node["LABORATORY"].InnerText;
                recipe.Yeasts.Add(yeast);
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}

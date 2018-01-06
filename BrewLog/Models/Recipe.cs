using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewLog.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; } = 1;
        public string Brewery { get; set; }
        public double? Volume { get; set; }
        public double? BoilSize { get; set; }
        public int? BoilTime { get; set; }
        public double? Efficiency { get; set; }
        public string Notes { get; set; }
        public string OriginalGravity { get; set; }
        public string FinalGravity { get; set; }
        public DateTime Date { get; set; }
        public List<Hop> Hops { get; set; }
        public List<Fermentable> Fermentables { get; set; }
        public List<Yeast> Yeasts { get; set; }
        public string IBU { get; set; }
        public string ABV { get; set; }
        public string Color { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewLog.Models
{
    public class Fermentable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; } = 1;
        public FermentableType Type { get; set; }
        public double Amount { get; set; }
        public float Color { get; set; }
        public bool? AddAfterBoil { get; set; }
        public string Notes { get; set; }

    }
}

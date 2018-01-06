using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewLog.Models
{
    public class Hop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; } = 1;
        public double Alpha { get; set; }
        public double Amount { get; set; }
        public HopUse Use { get; set; }
        public int Minutes { get; set; }
        public string Notes { get; set; }
        public HopType Type { get; set; }
        public HopForm Form { get; set; }
        public double? Beta { get; set; }
    }
}

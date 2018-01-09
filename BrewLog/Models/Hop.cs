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
        public string Use { get; set; }
        public int Minutes { get; set; }
        public string Notes { get; set; }
        public string Type { get; set; }
        public string Form { get; set; }
        public double? Beta { get; set; }
        public string DisplayAmount { get; set; }
        public string DisplayTime { get; set; }

    }
}

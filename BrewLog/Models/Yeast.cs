using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewLog.Models
{
    public class Yeast
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public YeastType Type { get; set; }
        public YeastForm Form { get; set; }
        public bool? AmountIsWeight { get; set; }
    }
}

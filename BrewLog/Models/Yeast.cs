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
        public string Type { get; set; }
        public string Form { get; set; }
        public string Notes { get; set; }
        public string ProductID { get; set; }
        public string Laboratory { get; set; }
    }
}

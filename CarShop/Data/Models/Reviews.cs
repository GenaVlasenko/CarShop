using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class Reviews
    {   
        public int id { get; set; }
        public string Car { get; set; }
        public string LinkOnVideo { get; set; }
        public string image { get; set; }
    }
}

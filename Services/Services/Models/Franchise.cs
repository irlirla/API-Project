using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Franchise
    {
        public int FranchiseID { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
